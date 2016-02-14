#include <stdlib.h>
#include <stdio.h>
#include <sys/sysinfo.h>
#include <math.h>
#include <pthread.h>

#define MAX_DATA 20
#define MIN(x, y) ((x) > (y) ? (y) : (x))

typedef struct {
	float x;
	float y;
	float z;
} Point;

struct dist_args {
	int start;
	int end;
};

static Point cities[MAX_DATA];
static float distances[MAX_DATA];
static int cities_cnt = 0;

static float averageDist = 0;

pthread_mutex_t lock;
pthread_t * threads;

static void *calc_distance(void * func_args) {
	struct dist_args * args = (struct dist_args * )func_args;
	int start = args->start;
	int end = args->end;

	for (int i = start; i < end; ++i) {
		float x1 = cities[i].x;
		float y1 = cities[i].y;
		float z1 = cities[i].z;
		float x2 = cities[i + 1].x;
		float y2 = cities[i + 1].y;
		float z2 = cities[i + 1].z;

		distances[i] = sqrt(pow(x1 - x2, 2) + pow(y1 - y2, 2.0) + pow(z1 - z2, 2.0));
		
		printf("Distance %d-%d: %f\n", i, i + 1, distances[i]);
	   	
		// Lock shared variable	
		pthread_mutex_lock(&lock);
		averageDist += distances[i];
		pthread_mutex_unlock(&lock);
	}
	
	free(args);
	pthread_exit(NULL);
}

static void calc_metrics() {
	int procs_cnt = get_nprocs();
	threads = (pthread_t *)malloc(sizeof(pthread_t) * procs_cnt);	
	int thr_cnt = 0;

	// Calculate thread creation step based on processors count
	int step = (cities_cnt - 1) / procs_cnt;
	if ((cities_cnt - 1) % procs_cnt != 0) {
		++step;
	}

	if (pthread_mutex_init(&lock, NULL) != 0) {
		printf("Mutex init failed\n");
		exit(1);
	}

	for (int i = 0; i < cities_cnt - 1; i += step) {
		int start = i;
		int end = MIN(cities_cnt - 1, i + step);

		// Init thread
		struct dist_args * args = malloc(sizeof *args);
		args->start = start;
		args->end = end;
		int rc = pthread_create(&threads[thr_cnt++], \
								NULL, \
								&calc_distance, \
								args);

		if (rc) {
			printf("ERROR. return code from pthread_create() is %d\n", rc);
			exit(-1);
		}
	}

	// Wait for all threads to exit
	for (int i = 0; i < thr_cnt; ++i) {
		int rc = pthread_join(threads[i], NULL);
		printf("Thread %d exited\n", i);
	}
	
	printf("Average distance: %f\n", averageDist / (cities_cnt - 1));
	free(threads);
}

static void read_input() {
	FILE *fp;
	fp = fopen("cities-list", "r");
	if (fp == NULL) {
		printf("Error opening file\n");
		exit(1);
	}
	
	char city_name[MAX_DATA];

	while (fscanf(fp, "%s", &city_name) == 1) {
		float x;
		float y;
		float z;
		fscanf(fp, "%f", &x);
		fscanf(fp, "%f", &y);
		fscanf(fp, "%f", &z);

		cities[cities_cnt].x = x;
		cities[cities_cnt].y = y;
		cities[cities_cnt].z = z;
		++cities_cnt;
	}

	int rc = fclose(fp);
	if (rc) {
		printf("Failed to close file\n");
		exit(1);
	}
}

int main(int argc, char ** argv) {
	read_input();
	calc_metrics();
}

#include <stdio.h>
#include <stdlib.h>
#include <pthread.h>
#include <math.h>
#include <sys/sysinfo.h>

#define MIN(x, y) ((x) > (y) ? (y) : (x))

typedef unsigned long long LL;

typedef struct {
	int start;
	int end;
} prime_args_t;

LL number;
LL border;
int isPrime = 1;

// thread utils
pthread_t * threads;

void * calculatePrime(void * args) {
	prime_args_t * prime_args = (prime_args_t *) args;
	int start = prime_args->start;
	int end = prime_args->end;

	for (int i = start; i <= end; ++i) {
		if (!isPrime) {
			break;
		}

		// printf("Thread %d: checking %d\n", pthread_self(), i);	
		
		if (number % i == 0) {
			// No need for mutex. The only possible assignment is 0.
			// Even if two threads access it at once, 
			// they would just both set it equal to 0
			isPrime = 0;
			// printf("NOT PRIME. Detected at %d\n", i);
			break;
		}
	}

	free(args);
	pthread_exit(NULL);
}

static void process_algo() {
	int procs_cnt = get_nprocs();
	threads = (pthread_t *) malloc(sizeof(pthread_t) * procs_cnt);
	int thr_cnt = 0;
	
	int step = (border - 1) / procs_cnt;
	if ( (border - 1) % procs_cnt != 0) {
		++step;
	}
	
	for (int i = 2; i <= border; i += step) {
		int start = i;
		int end = MIN(border, i + step - 1);
		prime_args_t * args = malloc(sizeof *args);
		args->start = start;
		args->end = end;
		int rc = pthread_create(&threads[thr_cnt++], NULL, &calculatePrime, args);

		if (rc) {
			printf("ERROR. failed to create thread\n");
			exit(-1);
		}
	}
	
	for (int i = 0; i < thr_cnt; ++i) {
		int rc = pthread_join(threads[i], NULL);
		printf("Thread %d exited\n", i);
	}

	free(threads);
}

static void read_input() {
	scanf("%llu", &number);
	border = (int)sqrt(number);
}

int main(int argc, char ** argv) {
	read_input();
	process_algo();
	printf("%d\n", isPrime);
}

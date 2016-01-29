#include <stdio.h>
#include <pthread.h>
#include <unistd.h>
#include <signal.h>

#define MAX_DATA 50000

pthread_t tId;

int primes[MAX_DATA];
int primes_cnt = 0;

// optimized eratosten sieve algorithm
void * calculatePrimes(void * arg) {
	int cnt = 2;
	while (1) {
		int isPrime = 1;
		for (int pIndex = 0; pIndex < primes_cnt; ++pIndex) {
			if (cnt % primes[pIndex] == 0) {
				isPrime = 0;
				break;
			}
		}

		if (isPrime) {
			primes[primes_cnt++] = cnt;
		}

		++cnt;
	}
}

int main(int argc, char ** argv) {
	pthread_create(&tId, NULL, &calculatePrimes, NULL);
	sleep(1.8);
	pthread_kill(tId, SIGSTOP);
	
	printf("%d primes found\n", primes_cnt);
	return 0;
}

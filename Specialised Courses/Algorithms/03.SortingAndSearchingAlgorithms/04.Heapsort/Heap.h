typedef struct
{
    int (*Init)(void *self);
    void (*Destroy)(void *self);
    void (*HeapifyDown)(int index);
    int (*Count)(void);
    int (*ExtractMin)(void);
    int (*PeekMin)(void);
    void (*Insert)(int node);
} Heap;

int Heap_init(void *self);
void Heap_destroy(void *self);
void HeapifyDown(int index);
int Count();
int ExtractMin();
int PeekMin();
void Insert(int node);
void *Heap_new(Heap proto);

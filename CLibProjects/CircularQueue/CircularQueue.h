#ifndef CIRCULARQUEUE_LIBRARY_H
#define CIRCULARQUEUE_LIBRARY_H

#include <stdio.h>
#include <stdlib.h>

typedef struct tagNode {
    int Data;
} Node;

typedef struct tagCircularQueue {
    int Capacity;
    int Front;
    int Rear;

    Node* Nodes;
} CircularQueue;

void CQ_CreateQueue(CircularQueue** Queue, int Capacity);
void CQ_DestroyQueue(CircularQueue* Queue);

void CQ_Enqueue(CircularQueue* Queue, int Data);
int CQ_Dequeue(CircularQueue* Queue);

int CQ_GetSize(CircularQueue* Queue);
int CQ_IsEmpty(CircularQueue* Queue);
int CQ_IsFull(CircularQueue* Queue);


#endif //CIRCULARQUEUE_LIBRARY_H
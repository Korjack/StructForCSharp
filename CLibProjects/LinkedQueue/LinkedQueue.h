#ifndef LINKEDQUEUE_LIBRARY_H
#define LINKEDQUEUE_LIBRARY_H

#include <stdio.h>
#include <stdlib.h>
#include <string.h>

typedef struct tagNode {
    char* Data;
    struct tagNode* NextNode;
} Node;

typedef struct tagLinkedQueue {
    Node* Front;
    Node* Rear;
    int Count;
} LinkedQueue;


void LQ_CreateQueue(LinkedQueue** Queue);
void LQ_DestroyQueue(LinkedQueue* Queue);

Node* LQ_CreateNode(char* NewData);
void LQ_DestroyNode(Node* _Node);

void LQ_Enqueue(LinkedQueue* Queue, Node* NewNode);
Node* LQ_Dequeue(LinkedQueue* Queue);

int LQ_IsEmpty(LinkedQueue* Queue);


#endif //LINKEDQUEUE_LIBRARY_H
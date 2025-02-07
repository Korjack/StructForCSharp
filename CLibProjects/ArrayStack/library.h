#ifndef ARRAYSTACK_LIBRARY_H
#define ARRAYSTACK_LIBRARY_H

#ifdef __cplusplus
extern "C" {
#endif

#include <stdio.h>
#include <stdlib.h>

typedef int ElementType;

typedef struct tagNode {
    ElementType Data;
} Node;

typedef struct tagArrayStack {
    int Capacity;
    int Top;
    Node* Nodes;
} ArrayStack;


void            AS_CreateStack(ArrayStack** Stack, int Capacity);
void            AS_DestroyStack(ArrayStack* Stack);
void            AS_Push(ArrayStack* Stack, ElementType Data);
ElementType     AS_Pop(ArrayStack* Stack);
ElementType     AS_Top(ArrayStack* Stack);
int             AS_GetSize(ArrayStack* Stack);
int             AS_IsEmpty(ArrayStack* Stack);
int             AS_IsFull(ArrayStack* Stack);


#ifdef __cplusplus
}
#endif

#endif //ARRAYSTACK_LIBRARY_H
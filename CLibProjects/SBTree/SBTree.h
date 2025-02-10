#ifndef SBTREE_LIBRARY_H
#define SBTREE_LIBRARY_H

#include <stdio.h>
#include <stdlib.h>

typedef struct tagSBTNode {
    struct tagSBTNode* Left;
    struct tagSBTNode* Right;

    char Data;
}SBTNode;


SBTNode* SBT_CreateNode(char Data);
void SBT_DestroyNode(SBTNode* Node);
void SBT_DestroyTree(SBTNode* Node);

void SBT_PreorderPrintTree(SBTNode* Node);
void SBT_InorderPrintTree(SBTNode* Node);
void SBT_PostorderPrintTree(SBTNode* Node);

#endif //SBTREE_LIBRARY_H
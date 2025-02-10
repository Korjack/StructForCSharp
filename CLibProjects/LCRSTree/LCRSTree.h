#ifndef LCRSTREE_LIBRARY_H
#define LCRSTREE_LIBRARY_H

#include <stdio.h>
#include <stdlib.h>


typedef struct tagLCRSNode {
    struct tagLCRSNode* LeftChild;
    struct tagLCRSNode* RightSibling;

    char Data;
} LCRSNode;


LCRSNode* LCRS_CreateNode(char NewData);
void LCRS_DestroyNode(LCRSNode* Node);

void LCRS_AddChildNode(LCRSNode* Parent, LCRSNode* Child);
void LCRS_PrintTree(LCRSNode* Node, int Depth);
void LCRS_PrintNodesAtLevel(LCRSNode* Root, int Depth, int Level);

#endif //LCRSTREE_LIBRARY_H
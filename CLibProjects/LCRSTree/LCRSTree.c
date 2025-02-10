#include "LCRSTree.h"

LCRSNode* LCRS_CreateNode(char NewData) {
    LCRSNode* NewNode = (LCRSNode*)malloc(sizeof(LCRSNode));

    // 초기화된 노드는 기본적으로 가리키는 대상이 없음.
    NewNode->LeftChild = NULL;
    NewNode->RightSibling = NULL;

    NewNode->Data = NewData;

    return NewNode;
}

void LCRS_DestroyNode(LCRSNode* Node) {

    if (Node->RightSibling != NULL) {
        LCRS_DestroyNode(Node->RightSibling);
    }

    if (Node->LeftChild != NULL) {
        LCRS_DestroyNode(Node->LeftChild);
    }

    Node->LeftChild = NULL;
    Node->RightSibling = NULL;

    free(Node);
}


void LCRS_AddChildNode(LCRSNode* Parent, LCRSNode* Child) {

    if (Parent->LeftChild == NULL) {
        Parent->LeftChild = Child;
    }
    else {
        LCRSNode* EndOfNode = Parent->LeftChild;

        while (EndOfNode->RightSibling != NULL) {
            EndOfNode = EndOfNode->RightSibling;
        }

        EndOfNode->RightSibling = Child;
    }
}

void LCRS_PrintTree(LCRSNode* Node, int Depth) {
    for (int i = 0; i < Depth-1; i++) {
        printf("   ");
    }

    if (Depth > 0) {
        printf("+---");
    }

    printf("%c\n", Node->Data);

    if (Node->LeftChild != NULL) {
        LCRS_PrintTree(Node->LeftChild, Depth+1);
    }

    if (Node->RightSibling != NULL) {
        LCRS_PrintTree(Node->RightSibling, Depth);
    }
}

void LCRS_PrintNodesAtLevel(LCRSNode* Root, int Depth, int Level)
{
    if (Level == Depth) {
        printf("%c ", Root->Data);

        if (Root->RightSibling != NULL) {
            LCRS_PrintNodesAtLevel(Root->RightSibling, Depth, Level);
        }
    }
    else {
        if (Root->LeftChild != NULL) {
            LCRS_PrintNodesAtLevel(Root->LeftChild, Depth+1, Level);
        }

        if (Root->RightSibling != NULL) {
            LCRS_PrintNodesAtLevel(Root->RightSibling, Depth, Level);
        }
    }
}
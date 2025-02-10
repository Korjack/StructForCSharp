#include "SBTree.h"

SBTNode* SBT_CreateNode(char Data) {
    SBTNode* NewNode = (SBTNode*)malloc(sizeof(SBTNode));

    // 기본 연결 해제
    NewNode->Left = NULL;
    NewNode->Right = NULL;

    // 새로운 데이터 설정
    NewNode->Data = Data;

    return NewNode;
}

void SBT_DestroyNode(SBTNode* Node) {
    free(Node);
}

void SBT_DestroyTree(SBTNode* Node) {
    if (Node == NULL) {
        return;
    }

    SBT_DestroyNode(Node->Left);

    SBT_DestroyNode(Node->Right);

    SBT_DestroyNode(Node);
}


void SBT_PreorderPrintTree(SBTNode* Node) {
    if (Node == NULL) {
        return;
    }

    // 현재 뿌리 출력
    printf(" %c", Node->Data);

    // 왼쪽 트리 탐색
    SBT_PreorderPrintTree(Node->Left);

    // 오른쪽 트리 탐색
    SBT_PreorderPrintTree(Node->Right);
}

void SBT_InorderPrintTree(SBTNode* Node) {
    if (Node == NULL) {
        return;
    }

    // 왼쪽 트리 탐색
    SBT_InorderPrintTree(Node->Left);

    // 현재 뿌리 출력
    printf(" %c", Node->Data);

    // 오른쪽 트리 탐색
    SBT_InorderPrintTree(Node->Right);
}

void SBT_PostorderPrintTree(SBTNode* Node) {
    if (Node == NULL) {
        return;
    }

    // 왼쪽 트리 탐색
    SBT_PostorderPrintTree(Node->Left);

    // 오른쪽 트리 탐색
    SBT_PostorderPrintTree(Node->Right);

    // 현재 뿌리 출력
    printf(" %c", Node->Data);
}
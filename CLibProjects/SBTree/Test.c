#include "SBTree.h"

void main() {
    // 트리 추가
    SBTNode* A = SBT_CreateNode('A');
    SBTNode* B = SBT_CreateNode('B');
    SBTNode* C = SBT_CreateNode('C');
    SBTNode* D = SBT_CreateNode('D');
    SBTNode* E = SBT_CreateNode('E');
    SBTNode* F = SBT_CreateNode('F');
    SBTNode* G = SBT_CreateNode('G');

    A->Left = B;
    B->Left = C;
    B->Right = D;

    A->Right = E;
    E->Left = F;
    E->Right = G;

    // 전위방식 트리 출력
    printf("Preorder... \n");
    SBT_PreorderPrintTree(A);
    printf("\n\n");

    // 중위방식 트리 출력
    printf("Inorder... \n");
    SBT_InorderPrintTree(A);
    printf("\n\n");

    // 후위방식 트리 출력
    printf("Postorder... \n");
    SBT_PostorderPrintTree(A);
    printf("\n\n");

    // 트리 삭제
    SBT_DestroyTree(A);
}
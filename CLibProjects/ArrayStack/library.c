#include "library.h"

void AS_CreateStack(ArrayStack** Stack, int Capacity) {
    // 스택 생성
    (*Stack) = (ArrayStack*)malloc(sizeof(ArrayStack));

    // Capacity 크기의 노드 생성
    (*Stack)->Nodes = (Node*)malloc(sizeof(Node) * Capacity);

    // 스택 변수 Init
    (*Stack)->Capacity = Capacity;
    (*Stack)->Top = -1;
}


void AS_DestroyStack(ArrayStack* Stack) {
    // 노드들을 메모리에서 해제
    free(Stack->Nodes);

    // 스택을 메모리에서 해제
    free(Stack);
}


void AS_Push(ArrayStack* Stack, ElementType Data) {
    // 스택의 탑 크기 증가
    Stack->Top++;

    // 노드 추가
    Stack->Nodes[Stack->Top].Data = Data;
}


ElementType AS_Pop(ArrayStack* Stack) {
    // 현재 위치를 저장하고, Top의 크기를 감소 시킴
    int Position = Stack->Top--;

    // 가져와야할 위치가 저장된 Position에서 데이터를 가져옴
    return Stack->Nodes[Position].Data;
}


ElementType AS_Top(ArrayStack* Stack) {
    return Stack->Nodes[Stack->Top].Data;
}


int AS_GetSize(ArrayStack* Stack) {
    return Stack->Top+1;
}


int AS_IsEmpty(ArrayStack* Stack) {
    return Stack->Top == -1;
}


int AS_IsFull(ArrayStack* Stack) {
    return (Stack->Top + 1) == Stack->Capacity;
}
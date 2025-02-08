cmake_minimum_required(VERSION 3.30)
project(LinkedListStack C)

set(CMAKE_C_STANDARD 11)

add_library(LinkedListStack SHARED LinkedListStack.c
        test.c)
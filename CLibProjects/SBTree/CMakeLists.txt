cmake_minimum_required(VERSION 3.30)
project(SBTree C)

set(CMAKE_C_STANDARD 17)

add_library(SBTree SHARED SBTree.c
        Test.c)

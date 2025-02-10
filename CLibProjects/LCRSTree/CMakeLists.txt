cmake_minimum_required(VERSION 3.30)
project(LCRSTree C)

set(CMAKE_C_STANDARD 17)

add_library(LCRSTree SHARED LCRSTree.c
        test.c)

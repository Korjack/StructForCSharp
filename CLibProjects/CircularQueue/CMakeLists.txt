cmake_minimum_required(VERSION 3.30)
project(CircularQueue C)

set(CMAKE_C_STANDARD 17)

add_library(CircularQueue SHARED CircularQueue.c)

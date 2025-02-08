cmake_minimum_required(VERSION 3.30)
project(LinkedQueue C)

set(CMAKE_C_STANDARD 17)

add_library(LinkedQueue SHARED LinkedQueue.c)

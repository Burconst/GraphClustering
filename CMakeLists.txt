# Задать минимальную версию CMake:
cmake_minimum_required(VERSION 3.0)

# Указать характеристики проекта:
project(MyProgram VERSION 1.0.0 LANGUAGES C CXX)

add_subdirectory(src)

add_subdirectory(test)

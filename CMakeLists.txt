cmake_minimum_required(VERSION 3.0)

# GraphClusteringLib
project(GraphClusteringLib VERSION 1.0.0 LANGUAGES C CXX)

# Build lib
add_subdirectory(src/build)

# Build test app
add_subdirectory(test/build)

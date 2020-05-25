cmake_minimum_required(VERSION 3.0)

# Включить поддержку тестирования:
enable_testing()

add_subdirectory(Graph)
add_subdirectory(Partition)
add_subdirectory(GraphClustering/Leiden)
add_subdirectory(GraphClustering/Louvain)
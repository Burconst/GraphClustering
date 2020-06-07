# Включить поддержку тестирования:
enable_testing()

include_directories(../Graph/)
include_directories(../Partition)
include_directories(../GraphClustering/Leiden)
include_directories(../GraphClustering/Louvain)

add_executable(GraphTests ../Graph/GraphTests.cpp)
target_link_libraries(GraphTests GraphClustering)

add_executable(PartitionTests ../Partition/PartitionTests.cpp)
target_link_libraries(PartitionTests GraphClustering)

add_executable(LeidenTests ../GraphClustering/Leiden/LeidenTests.cpp ../../src/Leiden.cpp)
target_link_libraries(LeidenTests GraphClustering)

add_executable(LouvainTests ../GraphClustering/Louvain/LouvainTests.cpp)
target_link_libraries(LouvainTests GraphClustering)

include(../Graph/TestList.cmake)
include(../Partition/TestList.cmake)
include(../GraphClustering/Louvain/TestList.cmake)
include(../GraphClustering/Leiden/TestList.cmake)
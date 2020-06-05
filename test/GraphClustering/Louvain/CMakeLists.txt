
set(LOUV_TIMEOUT 1)

add_executable(LouvainTests LouvainTests.cpp)
target_link_libraries(LouvainTests GraphClustering)

add_test(LouvTest1_1 LouvainTests test1 ./TestData/test1.bin)
add_test(LouvTest1_2 LouvainTests test1 ./TestData/test2.bin)
add_test(LouvTest1_3 LouvainTests test1 ./TestData/test3.bin)
add_test(LouvTest1_4 LouvainTests test1 ./TestData/test4.bin)
add_test(LouvTest1_5 LouvainTests test1 ./TestData/test5.bin)

set_tests_properties(LouvTest1_1 LouvTest1_2 LouvTest1_3 LouvTest1_4 LouvTest1_5
PROPERTIES TIMEOUT ${LOUV_TIMEOUT})

set(MULTIPLY_TIMEOUT 1)

add_executable(LouvainTest1 LouvainTest1.cpp)
target_link_libraries(LouvainTest1 GraphClustering)

add_test(Louv1Test1 LouvainTest1 ./TestData/test1.bin)
add_test(Louv1Test2 LouvainTest1 ./TestData/test2.bin)
add_test(Louv1Test3 LouvainTest1 ./TestData/test3.bin)
add_test(Louv1Test4 LouvainTest1 ./TestData/test4.bin)
add_test(Louv1Test5 LouvainTest1 ./TestData/test5.bin)
# add_test(Louv1Test6 LouvainTest1 ./test5.bin)


set_tests_properties(Louv1Test1 Louv1Test2 Louv1Test3 Louv1Test4 Louv1Test5 #Louv1Test6
PROPERTIES TIMEOUT ${MULTIPLY_TIMEOUT})
# set_tests_properties(Leid1Test1 PROPERTIES
# PASS_REGULAR_EXPRESSION "{ 1  2  3  5  6 }")

set(MULTIPLY_TIMEOUT 1)


# GraphTest1

add_executable(GraphTest1 GraphTest1.cpp)
target_link_libraries(GraphTest1 GraphClustering)

add_test(G1Test1 GraphTest1 ./TestData/test1.bin 2 0 9)
add_test(G1Test2 GraphTest1 ./TestData/test2.bin 8 1 0)
add_test(G1Test3 GraphTest1 ./TestData/test3.bin 17 0 24)
add_test(G1Test4 GraphTest1 ./TestData/test4.bin 16 0 20)
add_test(G1Test5 GraphTest1 ./TestData/test5.bin 10 4 6)

set_tests_properties(G1Test1 G1Test2 G1Test3 G1Test4 G1Test5
PROPERTIES TIMEOUT ${MULTIPLY_TIMEOUT})
set_tests_properties(G1Test1 PROPERTIES
PASS_REGULAR_EXPRESSION "3 4 1")
set_tests_properties(G1Test2 PROPERTIES
PASS_REGULAR_EXPRESSION "3 2 3")
set_tests_properties(G1Test3 PROPERTIES
PASS_REGULAR_EXPRESSION "2 14 1")
set_tests_properties(G1Test4 PROPERTIES
PASS_REGULAR_EXPRESSION "2 4 1")
set_tests_properties(G1Test5 PROPERTIES
PASS_REGULAR_EXPRESSION "2 6 4")


# GraphTest2

add_executable(GraphTest2 GraphTest2.cpp)
target_link_libraries(GraphTest2 GraphClustering)

add_test(G2Test1 GraphTest2 ./TestData/test1.bin 8 3 2)
add_test(G2Test2 GraphTest2 ./TestData/test2.bin 8 6 7)
add_test(G2Test3 GraphTest2 ./TestData/test3.bin 0 16 29)
add_test(G2Test4 GraphTest2 ./TestData/test4.bin 5 18 7)
add_test(G2Test5 GraphTest2 ./TestData/test5.bin 4 5 0)

set_tests_properties(G2Test1 G2Test2 G2Test3 G2Test4 G2Test5
PROPERTIES TIMEOUT ${MULTIPLY_TIMEOUT})
set_tests_properties(G2Test1 PROPERTIES
PASS_REGULAR_EXPRESSION "0 1 0")
set_tests_properties(G2Test2 PROPERTIES
PASS_REGULAR_EXPRESSION "1 0 1")
set_tests_properties(G2Test3 PROPERTIES
PASS_REGULAR_EXPRESSION "1 0 0")
set_tests_properties(G2Test4 PROPERTIES
PASS_REGULAR_EXPRESSION "0 0 0")
set_tests_properties(G2Test5 PROPERTIES
PASS_REGULAR_EXPRESSION "1 1 0")

# GraphTest3

add_executable(GraphTest3 GraphTest3.cpp)
target_link_libraries(GraphTest3 GraphClustering)

add_test(G3Test1 GraphTest3 ./TestData/test1.bin 0 1 9)
add_test(G3Test2 GraphTest3 ./TestData/test2.bin 5 7 3)
add_test(G3Test3 GraphTest3 ./TestData/test3.bin 27 10 0)
add_test(G3Test4 GraphTest3 ./TestData/test4.bin 21 9 14)
add_test(G3Test5 GraphTest3 ./TestData/test5.bin 8 7 11)

set_tests_properties(G3Test1 G3Test2 G3Test3 G3Test4 G3Test5
PROPERTIES TIMEOUT ${MULTIPLY_TIMEOUT})
set_tests_properties(G3Test1 PROPERTIES
PASS_REGULAR_EXPRESSION "1 4 8 ;0 2 3 5 ;5 ;")
set_tests_properties(G3Test2 PROPERTIES
PASS_REGULAR_EXPRESSION "1 2 ;0 6 ;8 2 1 9 ;")
set_tests_properties(G3Test3 PROPERTIES
PASS_REGULAR_EXPRESSION "0 28 ;9 12 ;0 2 3 6 11 12 13 18 19 24 26 27 29 30 ;")
set_tests_properties(G3Test4 PROPERTIES
PASS_REGULAR_EXPRESSION "0 15 22 23 ;6 ;10 19 20 ;")
set_tests_properties(G3Test5 PROPERTIES
PASS_REGULAR_EXPRESSION "1 4 5 9 ;3 6 ;5 6 13 ;")
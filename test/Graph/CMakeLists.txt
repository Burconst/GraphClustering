
set(MULTIPLY_TIMEOUT 1)

# GraphTest1 Degree of node

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


# GraphTest2 Selfloops of node

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

# GraphTest3 Neigh. nodes

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

# GraphTest4 Copy operator

add_executable(GraphTest4 GraphTest4.cpp)
target_link_libraries(GraphTest4 GraphClustering)

add_test(G4Test1 GraphTest4 ./TestData/test1.bin)
add_test(G4Test2 GraphTest4 ./TestData/test2.bin)
add_test(G4Test3 GraphTest4 ./TestData/test3.bin)
add_test(G4Test4 GraphTest4 ./TestData/test4.bin)
add_test(G4Test5 GraphTest4 ./TestData/test5.bin)

set_tests_properties(G4Test1 PROPERTIES
PASS_REGULAR_EXPRESSION "Success"
FAIL_REGULAR_EXPRESSION "Error")
set_tests_properties(G4Test2 PROPERTIES
PASS_REGULAR_EXPRESSION "Success"
FAIL_REGULAR_EXPRESSION "Error")
set_tests_properties(G4Test3 PROPERTIES
PASS_REGULAR_EXPRESSION "Success"
FAIL_REGULAR_EXPRESSION "Error")
set_tests_properties(G4Test4 PROPERTIES
PASS_REGULAR_EXPRESSION "Success"
FAIL_REGULAR_EXPRESSION "Error")
set_tests_properties(G4Test5 PROPERTIES
PASS_REGULAR_EXPRESSION "Success"
FAIL_REGULAR_EXPRESSION "Error")

# GraphTest5 operator ==

add_executable(GraphTest5 GraphTest5.cpp)
target_link_libraries(GraphTest5 GraphClustering)

add_test(G5Test1 GraphTest5 ./TestData/test1.bin ./TestData/test1.bin)
add_test(G5Test2 GraphTest5 ./TestData/test1.bin ./TestData/test2.bin)
add_test(G5Test3 GraphTest5 ./TestData/test1.bin ./TestData/nottest1.bin)

set_tests_properties(G5Test1 PROPERTIES
PASS_REGULAR_EXPRESSION "Equal")
set_tests_properties(G5Test2 PROPERTIES
PASS_REGULAR_EXPRESSION "Not Equal")
set_tests_properties(G5Test3 PROPERTIES
PASS_REGULAR_EXPRESSION "Not Equal")

# GraphTest6 Norm of node

add_executable(GraphTest6 GraphTest6.cpp)
target_link_libraries(GraphTest6 GraphClustering)

add_test(G6Test1 GraphTest6 ./TestData/test1.bin 2 0 9)
add_test(G6Test2 GraphTest6 ./TestData/test2.bin 8 1 0)
add_test(G6Test3 GraphTest6 ./TestData/test3.bin 17 0 24)
add_test(G6Test4 GraphTest6 ./TestData/test4.bin 16 0 20)
add_test(G6Test5 GraphTest6 ./TestData/test5.bin 10 4 6)

set_tests_properties(G1Test1 G1Test2 G1Test3 G1Test4 G1Test5
PROPERTIES TIMEOUT ${MULTIPLY_TIMEOUT})
set_tests_properties(G6Test1 PROPERTIES
PASS_REGULAR_EXPRESSION "1 1 1")
set_tests_properties(G6Test2 PROPERTIES
PASS_REGULAR_EXPRESSION "1 1 1")
set_tests_properties(G6Test3 PROPERTIES
PASS_REGULAR_EXPRESSION "1 1 1")
set_tests_properties(G6Test4 PROPERTIES
PASS_REGULAR_EXPRESSION "1 1 1")
set_tests_properties(G6Test5 PROPERTIES
PASS_REGULAR_EXPRESSION "1 1 1")


# GraphTest7 Norm of node in agr network

add_executable(GraphTest7 GraphTest7.cpp)
target_link_libraries(GraphTest7 GraphClustering)

add_test(G7Test1 GraphTest7 ./TestData/test1.bin ./TestData/comm1.txt 1 0 2)
add_test(G7Test2 GraphTest7 ./TestData/test2.bin ./TestData/comm2.txt 0 1 2)
add_test(G7Test3 GraphTest7 ./TestData/test3.bin ./TestData/comm3.txt 4 3 0)
add_test(G7Test4 GraphTest7 ./TestData/test4.bin ./TestData/comm4.txt 0 3 1)
add_test(G7Test5 GraphTest7 ./TestData/test5.bin ./TestData/comm5.txt 0 2 3)

set_tests_properties(G7Test1 G7Test2 G7Test3 G7Test4 G7Test5
PROPERTIES TIMEOUT ${MULTIPLY_TIMEOUT})
set_tests_properties(G7Test1 PROPERTIES
PASS_REGULAR_EXPRESSION "5 2 3")
set_tests_properties(G7Test2 PROPERTIES
PASS_REGULAR_EXPRESSION "3 4 3")
set_tests_properties(G7Test3 PROPERTIES
PASS_REGULAR_EXPRESSION "4 7 8")
set_tests_properties(G7Test4 PROPERTIES
PASS_REGULAR_EXPRESSION "9 6 5")
set_tests_properties(G7Test5 PROPERTIES
PASS_REGULAR_EXPRESSION "5 5 2")




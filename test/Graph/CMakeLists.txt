
add_executable(GraphTests GraphTests.cpp)
target_link_libraries(GraphTests GraphClustering)

set(TEST_TIMEOUT 1)

# GraphTest1 Degree of node
add_test(GraphTest1_1 GraphTests test1 ./TestData/test1.bin 2 0 9)
add_test(GraphTest1_2 GraphTests test1 ./TestData/test2.bin 8 1 0)
add_test(GraphTest1_3 GraphTests test1 ./TestData/test3.bin 17 0 24)
add_test(GraphTest1_4 GraphTests test1 ./TestData/test4.bin 16 0 20)
add_test(GraphTest1_5 GraphTests test1 ./TestData/test5.bin 10 4 6)

set_tests_properties(GraphTest1_1 GraphTest1_2 GraphTest1_3 GraphTest1_4 GraphTest1_5
PROPERTIES TIMEOUT ${TEST_TIMEOUT})
set_tests_properties(GraphTest1_1 PROPERTIES
PASS_REGULAR_EXPRESSION "3 4 1")
set_tests_properties(GraphTest1_2 PROPERTIES
PASS_REGULAR_EXPRESSION "3 2 3")
set_tests_properties(GraphTest1_3 PROPERTIES
PASS_REGULAR_EXPRESSION "2 14 1")
set_tests_properties(GraphTest1_4 PROPERTIES
PASS_REGULAR_EXPRESSION "2 4 1")
set_tests_properties(GraphTest1_5 PROPERTIES
PASS_REGULAR_EXPRESSION "2 6 4")


# GraphTest2 Selfloops of node
add_test(GraphTest2_1 GraphTests test2 ./TestData/test1.bin 8 3 2)
add_test(GraphTest2_2 GraphTests test2 ./TestData/test2.bin 8 6 7)
add_test(GraphTest2_3 GraphTests test2 ./TestData/test3.bin 0 16 29)
add_test(GraphTest2_4 GraphTests test2 ./TestData/test4.bin 5 18 7)
add_test(GraphTest2_5 GraphTests test2 ./TestData/test5.bin 4 5 0)

set_tests_properties(GraphTest2_1 GraphTest2_2 GraphTest2_3 GraphTest2_4 GraphTest2_5
PROPERTIES TIMEOUT ${TEST_TIMEOUT})
set_tests_properties(GraphTest2_1 PROPERTIES
PASS_REGULAR_EXPRESSION "0 1 0")
set_tests_properties(GraphTest2_2 PROPERTIES
PASS_REGULAR_EXPRESSION "1 0 1")
set_tests_properties(GraphTest2_3 PROPERTIES
PASS_REGULAR_EXPRESSION "1 0 0")
set_tests_properties(GraphTest2_4 PROPERTIES
PASS_REGULAR_EXPRESSION "0 0 0")
set_tests_properties(GraphTest2_5 PROPERTIES
PASS_REGULAR_EXPRESSION "1 1 0")


# GraphTest3 Neigh. nodes
add_test(GraphTest3_1 GraphTests test3 ./TestData/test1.bin 0 1 9)
add_test(GraphTest3_2 GraphTests test3 ./TestData/test2.bin 5 7 3)
add_test(GraphTest3_3 GraphTests test3 ./TestData/test3.bin 27 10 0)
add_test(GraphTest3_4 GraphTests test3 ./TestData/test4.bin 21 9 14)
add_test(GraphTest3_5 GraphTests test3 ./TestData/test5.bin 8 7 11)

set_tests_properties(GraphTest3_1 GraphTest3_2 GraphTest3_3 GraphTest3_4 GraphTest3_5
PROPERTIES TIMEOUT ${TEST_TIMEOUT})
set_tests_properties(GraphTest3_1 PROPERTIES
PASS_REGULAR_EXPRESSION "1 4 8 ;0 2 3 5 ;5 ;")
set_tests_properties(GraphTest3_2 PROPERTIES
PASS_REGULAR_EXPRESSION "1 2 ;0 6 ;8 2 1 9 ;")
set_tests_properties(GraphTest3_3 PROPERTIES
PASS_REGULAR_EXPRESSION "0 28 ;9 12 ;0 2 3 6 11 12 13 18 19 24 26 27 29 30 ;")
set_tests_properties(GraphTest3_4 PROPERTIES
PASS_REGULAR_EXPRESSION "0 15 22 23 ;6 ;10 19 20 ;")
set_tests_properties(GraphTest3_5 PROPERTIES
PASS_REGULAR_EXPRESSION "1 4 5 9 ;3 6 ;5 6 13 ;")


# GraphTest4 Copy operator
add_test(GraphTest4_1 GraphTests test4 ./TestData/test1.bin)
add_test(GraphTest4_2 GraphTests test4 ./TestData/test2.bin)
add_test(GraphTest4_3 GraphTests test4 ./TestData/test3.bin)
add_test(GraphTest4_4 GraphTests test4 ./TestData/test4.bin)
add_test(GraphTest4_5 GraphTests test4 ./TestData/test5.bin)

set_tests_properties(GraphTest4_1 GraphTest4_2 GraphTest4_3 GraphTest4_4 GraphTest4_5
PROPERTIES TIMEOUT ${TEST_TIMEOUT})
set_tests_properties(GraphTest4_1 PROPERTIES
PASS_REGULAR_EXPRESSION "Success"
FAIL_REGULAR_EXPRESSION "Error")
set_tests_properties(GraphTest4_2 PROPERTIES
PASS_REGULAR_EXPRESSION "Success"
FAIL_REGULAR_EXPRESSION "Error")
set_tests_properties(GraphTest4_3 PROPERTIES
PASS_REGULAR_EXPRESSION "Success"
FAIL_REGULAR_EXPRESSION "Error")
set_tests_properties(GraphTest4_4 PROPERTIES
PASS_REGULAR_EXPRESSION "Success"
FAIL_REGULAR_EXPRESSION "Error")
set_tests_properties(GraphTest4_5 PROPERTIES
PASS_REGULAR_EXPRESSION "Success"
FAIL_REGULAR_EXPRESSION "Error")


# GraphTest5 operator ==
add_test(GraphTest5_1 GraphTests test5 ./TestData/test1.bin ./TestData/test1.bin)
add_test(GraphTest5_2 GraphTests test5 ./TestData/test1.bin ./TestData/test2.bin)
add_test(GraphTest5_3 GraphTests test5 ./TestData/test1.bin ./TestData/nottest1.bin)

set_tests_properties(GraphTest5_1 GraphTest5_2 GraphTest5_3
PROPERTIES TIMEOUT ${TEST_TIMEOUT})
set_tests_properties(GraphTest5_1 PROPERTIES
PASS_REGULAR_EXPRESSION "Equal")
set_tests_properties(GraphTest5_2 PROPERTIES
PASS_REGULAR_EXPRESSION "Not Equal")
set_tests_properties(GraphTest5_3 PROPERTIES
PASS_REGULAR_EXPRESSION "Not Equal")


# GraphTest6 Norm of node
add_test(GraphTest6_1 GraphTests test6 ./TestData/test1.bin 2 0 9)
add_test(GraphTest6_2 GraphTests test6 ./TestData/test2.bin 8 1 0)
add_test(GraphTest6_3 GraphTests test6 ./TestData/test3.bin 17 0 24)
add_test(GraphTest6_4 GraphTests test6 ./TestData/test4.bin 16 0 20)
add_test(GraphTest6_5 GraphTests test6 ./TestData/test5.bin 10 4 6)

set_tests_properties(GraphTest6_1 GraphTest6_2 GraphTest6_3 GraphTest6_4 GraphTest6_5
PROPERTIES TIMEOUT ${TEST_TIMEOUT})
set_tests_properties(GraphTest6_1 PROPERTIES
PASS_REGULAR_EXPRESSION "1 1 1")
set_tests_properties(GraphTest6_2 PROPERTIES
PASS_REGULAR_EXPRESSION "1 1 1")
set_tests_properties(GraphTest6_3 PROPERTIES
PASS_REGULAR_EXPRESSION "1 1 1")
set_tests_properties(GraphTest6_4 PROPERTIES
PASS_REGULAR_EXPRESSION "1 1 1")
set_tests_properties(GraphTest6_5 PROPERTIES
PASS_REGULAR_EXPRESSION "1 1 1")


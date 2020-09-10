set(TST_DIR "../TestData")

set(TEST_TIMEOUT 1)

# Test1 NeighComm
add_test(PartitionTest1_1 PartitionTests test1 ${TST_DIR}/test1.bin ${TST_DIR}/comm1.txt 6 3 9)
add_test(PartitionTest1_2 PartitionTests test1 ${TST_DIR}/test2.bin ${TST_DIR}/comm2.txt 7 5 3)
add_test(PartitionTest1_3 PartitionTests test1 ${TST_DIR}/test3.bin ${TST_DIR}/comm3.txt 0 29 15)
add_test(PartitionTest1_4 PartitionTests test1 ${TST_DIR}/test4.bin ${TST_DIR}/comm4.txt 0 8 10)
add_test(PartitionTest1_5 PartitionTests test1 ${TST_DIR}/test5.bin ${TST_DIR}/comm5.txt 5 4 11)

set_tests_properties(PartitionTest1_1 PartitionTest1_2 PartitionTest1_3 PartitionTest1_4 PartitionTest1_5
PROPERTIES TIMEOUT ${TEST_TIMEOUT})
set_tests_properties(PartitionTest1_1 PROPERTIES
PASS_REGULAR_EXPRESSION "{ 1  2 }{ 0  1  2 }{ 0 }")
set_tests_properties(PartitionTest1_2 PROPERTIES
PASS_REGULAR_EXPRESSION "{ 0  1 }{ 2 }{ 1  2 }")
set_tests_properties(PartitionTest1_3 PROPERTIES
PASS_REGULAR_EXPRESSION "{ 0  1  2  3  4 }{ 0  4 }{ 3 }")
set_tests_properties(PartitionTest1_4 PROPERTIES
PASS_REGULAR_EXPRESSION "{ 0  2  3 }{ 0  1 }{ 1  2  3 }")
set_tests_properties(PartitionTest1_5 PROPERTIES
PASS_REGULAR_EXPRESSION "{ 0  2  3 }{ 0  1  2 }{ 0  2  3 }")

# Test2 getComm
add_test(PartitionTest2_1 PartitionTests test2 ${TST_DIR}/test1.bin ${TST_DIR}/comm1.txt)
add_test(PartitionTest2_2 PartitionTests test2 ${TST_DIR}/test2.bin ${TST_DIR}/comm2.txt)
add_test(PartitionTest2_3 PartitionTests test2 ${TST_DIR}/test3.bin ${TST_DIR}/comm3.txt)
add_test(PartitionTest2_4 PartitionTests test2 ${TST_DIR}/test4.bin ${TST_DIR}/comm4.txt)
add_test(PartitionTest2_5 PartitionTests test2 ${TST_DIR}/test5.bin ${TST_DIR}/comm5.txt)

set_tests_properties(PartitionTest2_1 PartitionTest2_2 PartitionTest2_3 PartitionTest2_4 PartitionTest2_5
PROPERTIES TIMEOUT ${TEST_TIMEOUT})
set_tests_properties(PartitionTest2_1 PROPERTIES
PASS_REGULAR_EXPRESSION "{ 0  1  2 }")
set_tests_properties(PartitionTest2_2 PROPERTIES
PASS_REGULAR_EXPRESSION "{ 0  1  2 }")
set_tests_properties(PartitionTest2_3 PROPERTIES
PASS_REGULAR_EXPRESSION "{ 0  1  2  3  4 }") 
set_tests_properties(PartitionTest2_4 PROPERTIES
PASS_REGULAR_EXPRESSION "{ 0  1  2  3 }")
set_tests_properties(PartitionTest2_5 PROPERTIES
PASS_REGULAR_EXPRESSION "{ 0  1  2  3 }")


# PartitionTest3 operator ==
add_test(PartitionTest3_1 PartitionTests test3 ${TST_DIR}/test1.bin ${TST_DIR}/comm1.txt ${TST_DIR}/test1.bin ${TST_DIR}/comm1.txt)
add_test(PartitionTest3_2 PartitionTests test3  ${TST_DIR}/test1.bin ${TST_DIR}/comm1.txt ${TST_DIR}/test1.bin ${TST_DIR}/notcomm1.txt)
add_test(PartitionTest3_3 PartitionTests test3 ${TST_DIR}/test1.bin ${TST_DIR}/comm1.txt ${TST_DIR}/test2.bin ${TST_DIR}/comm2.txt)

set_tests_properties(PartitionTest3_1 PartitionTest3_2 PartitionTest3_3
PROPERTIES TIMEOUT ${TEST_TIMEOUT})
set_tests_properties(PartitionTest3_1 PROPERTIES
PASS_REGULAR_EXPRESSION "Equal")
set_tests_properties(PartitionTest3_2 PROPERTIES
PASS_REGULAR_EXPRESSION "Not Equal")
set_tests_properties(PartitionTest3_3 PROPERTIES
PASS_REGULAR_EXPRESSION "Not Equal")

# PartitionTest4 copy operator
add_test(PartitionTest4_1 PartitionTests test4 ${TST_DIR}/test1.bin ${TST_DIR}/comm1.txt)
add_test(PartitionTest4_2 PartitionTests test4 ${TST_DIR}/test2.bin ${TST_DIR}/comm2.txt)
add_test(PartitionTest4_3 PartitionTests test4 ${TST_DIR}/test3.bin ${TST_DIR}/comm3.txt)
add_test(PartitionTest4_4 PartitionTests test4 ${TST_DIR}/test4.bin ${TST_DIR}/comm4.txt)
add_test(PartitionTest4_5 PartitionTests test4 ${TST_DIR}/test5.bin ${TST_DIR}/comm5.txt)

set_tests_properties(PartitionTest4_1 PartitionTest4_2 PartitionTest4_3 PartitionTest4_4 PartitionTest4_5
PROPERTIES TIMEOUT ${TEST_TIMEOUT})
set_tests_properties(PartitionTest4_1 PROPERTIES
PASS_REGULAR_EXPRESSION "Equal")
set_tests_properties(PartitionTest4_2 PROPERTIES
PASS_REGULAR_EXPRESSION "Equal")
set_tests_properties(PartitionTest4_3 PROPERTIES
PASS_REGULAR_EXPRESSION "Equal")
set_tests_properties(PartitionTest4_4 PROPERTIES
PASS_REGULAR_EXPRESSION "Equal")
set_tests_properties(PartitionTest4_5 PROPERTIES
PASS_REGULAR_EXPRESSION "Equal")


# PartitionTest5 AggregatePartition
add_test(PartitionTest5_1 PartitionTests test5 ${TST_DIR}/test1.bin ${TST_DIR}/comm1.txt ${TST_DIR}/agrtest1.bin)
add_test(PartitionTest5_2 PartitionTests test5 ${TST_DIR}/test2.bin ${TST_DIR}/comm2.txt ${TST_DIR}/agrtest2.bin)
add_test(PartitionTest5_3 PartitionTests test5 ${TST_DIR}/test3.bin ${TST_DIR}/comm3.txt ${TST_DIR}/agrtest3.bin)
add_test(PartitionTest5_4 PartitionTests test5 ${TST_DIR}/test4.bin ${TST_DIR}/comm4.txt ${TST_DIR}/agrtest4.bin)
add_test(PartitionTest5_5 PartitionTests test5 ${TST_DIR}/test5.bin ${TST_DIR}/comm5.txt ${TST_DIR}/agrtest5.bin)
add_test(PartitionTest5_6 PartitionTests test5 ${TST_DIR}/test1.bin ${TST_DIR}/comm1.txt ${TST_DIR}/notagrtest1.bin)

set_tests_properties(PartitionTest5_1 PartitionTest5_2 PartitionTest5_3 PartitionTest5_4 PartitionTest5_5 PartitionTest5_6
PROPERTIES TIMEOUT ${TEST_TIMEOUT})
set_tests_properties(PartitionTest5_1 PROPERTIES
PASS_REGULAR_EXPRESSION "Equal")
set_tests_properties(PartitionTest5_2 PROPERTIES
PASS_REGULAR_EXPRESSION "Equal")
set_tests_properties(PartitionTest5_3 PROPERTIES
PASS_REGULAR_EXPRESSION "Equal")
set_tests_properties(PartitionTest5_4 PROPERTIES
PASS_REGULAR_EXPRESSION "Equal")
set_tests_properties(PartitionTest5_5 PROPERTIES
PASS_REGULAR_EXPRESSION "Equal")
set_tests_properties(PartitionTest5_6 PROPERTIES
PASS_REGULAR_EXPRESSION "Not Equal")


# PartitionTest6 Norm of community
add_test(PartitionTest6_1 PartitionTests test6 ${TST_DIR}/test1.bin ${TST_DIR}/comm1.txt 1 0 2)
add_test(PartitionTest6_2 PartitionTests test6 ${TST_DIR}/test2.bin ${TST_DIR}/comm2.txt 0 1 2)
add_test(PartitionTest6_3 PartitionTests test6 ${TST_DIR}/test3.bin ${TST_DIR}/comm3.txt 4 3 0)
add_test(PartitionTest6_4 PartitionTests test6 ${TST_DIR}/test4.bin ${TST_DIR}/comm4.txt 0 3 1)
add_test(PartitionTest6_5 PartitionTests test6 ${TST_DIR}/test5.bin ${TST_DIR}/comm5.txt 0 2 3)

set_tests_properties(PartitionTest6_1 PartitionTest6_2 PartitionTest6_3 PartitionTest6_4 PartitionTest6_5
PROPERTIES TIMEOUT ${TEST_TIMEOUT})
set_tests_properties(PartitionTest6_1 PROPERTIES
PASS_REGULAR_EXPRESSION "5 2 3")
set_tests_properties(PartitionTest6_2 PROPERTIES
PASS_REGULAR_EXPRESSION "3 4 3")
set_tests_properties(PartitionTest6_3 PROPERTIES
PASS_REGULAR_EXPRESSION "4 7 8")
set_tests_properties(PartitionTest6_4 PROPERTIES
PASS_REGULAR_EXPRESSION "9 6 5")
set_tests_properties(PartitionTest6_5 PROPERTIES
PASS_REGULAR_EXPRESSION "5 5 2") 

# GraphTest7 Norm of node in agr network
add_test(PartitionTest7_1 PartitionTests test7 ${TST_DIR}/test1.bin ${TST_DIR}/comm1.txt 1 0 2)
add_test(PartitionTest7_2 PartitionTests test7 ${TST_DIR}/test2.bin ${TST_DIR}/comm2.txt 0 1 2)
add_test(PartitionTest7_3 PartitionTests test7 ${TST_DIR}/test3.bin ${TST_DIR}/comm3.txt 4 3 0)
add_test(PartitionTest7_4 PartitionTests test7 ${TST_DIR}/test4.bin ${TST_DIR}/comm4.txt 0 3 1)
add_test(PartitionTest7_5 PartitionTests test7 ${TST_DIR}/test5.bin ${TST_DIR}/comm5.txt 0 2 3)

set_tests_properties(PartitionTest7_1 PartitionTest7_2 PartitionTest7_3 PartitionTest7_4 PartitionTest7_5
PROPERTIES TIMEOUT ${TEST_TIMEOUT})
set_tests_properties(PartitionTest7_1 PROPERTIES
PASS_REGULAR_EXPRESSION "5 2 3")
set_tests_properties(PartitionTest7_2 PROPERTIES
PASS_REGULAR_EXPRESSION "3 4 3")
set_tests_properties(PartitionTest7_3 PROPERTIES
PASS_REGULAR_EXPRESSION "4 7 8")
set_tests_properties(PartitionTest7_4 PROPERTIES
PASS_REGULAR_EXPRESSION "9 6 5")
set_tests_properties(PartitionTest7_5 PROPERTIES
PASS_REGULAR_EXPRESSION "5 5 2")
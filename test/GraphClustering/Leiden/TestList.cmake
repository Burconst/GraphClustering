set(TST_DIR "../TestData")

set(LDN_TIMEOUT 1)

# LeidenTest1 getMarkedNodes
add_test(LeidTest1_1 LeidenTests test1 ${TST_DIR}/test1.bin ${TST_DIR}/comm1.txt)
add_test(LeidTest1_2 LeidenTests test1 ${TST_DIR}/test2.bin ${TST_DIR}/comm2.txt)
add_test(LeidTest1_3 LeidenTests test1 ${TST_DIR}/test3.bin ${TST_DIR}/comm3.txt)
add_test(LeidTest1_4 LeidenTests test1 ${TST_DIR}/test4.bin ${TST_DIR}/comm4.txt)
add_test(LeidTest1_5 LeidenTests test1 ${TST_DIR}/test5.bin ${TST_DIR}/comm5.txt)

set_tests_properties(LeidTest1_1 LeidTest1_2 LeidTest1_3 LeidTest1_4 LeidTest1_5
PROPERTIES TIMEOUT ${LDN_TIMEOUT})
set_tests_properties(LeidTest1_1 PROPERTIES
PASS_REGULAR_EXPRESSION "{ 1  2  3  5  6 }")
set_tests_properties(LeidTest1_2 PROPERTIES
PASS_REGULAR_EXPRESSION "{ 0  1  2  3  7 }")
# set_tests_properties(LeidTest1_3 PROPERTIES
# PASS_REGULAR_EXPRESSION "{ 0  2  6  11  12  13  18  19  24  26  27  29  30 }")
set_tests_properties(LeidTest1_4 PROPERTIES
PASS_REGULAR_EXPRESSION "{ 0  1  8  10  13  14  15  16  21 }")
set_tests_properties(LeidTest1_5 PROPERTIES
PASS_REGULAR_EXPRESSION "{ 1  4  5  6  8  11 }")


# LeidenTest2 getWellConnectedNodes
add_test(LeidTest2_1 LeidenTests test2 ${TST_DIR}/test1.bin ${TST_DIR}/comm1.txt 0 1 2 4 8)
add_test(LeidTest2_2 LeidenTests test2 ${TST_DIR}/test2.bin ${TST_DIR}/comm2.txt 0 3 8 9)
add_test(LeidTest2_3 LeidenTests test2 ${TST_DIR}/test3.bin ${TST_DIR}/comm3.txt 0 3 4 5)
add_test(LeidTest2_4 LeidenTests test2 ${TST_DIR}/test4.bin ${TST_DIR}/comm4.txt 15 21 22 23)
add_test(LeidTest2_5 LeidenTests test2 ${TST_DIR}/test5.bin ${TST_DIR}/comm5.txt 2 3 4 6 7)

set_tests_properties(LeidTest2_1 LeidTest2_2 LeidTest2_3 LeidTest2_4 LeidTest2_5
PROPERTIES TIMEOUT ${LDN_TIMEOUT})
set_tests_properties(LeidTest2_1 PROPERTIES
PASS_REGULAR_EXPRESSION "{ 0 }")
set_tests_properties(LeidTest2_2 PROPERTIES
PASS_REGULAR_EXPRESSION "{ 8 }")
set_tests_properties(LeidTest2_3 PROPERTIES
PASS_REGULAR_EXPRESSION "{}")
set_tests_properties(LeidTest2_4 PROPERTIES
PASS_REGULAR_EXPRESSION "{ 21 }")
set_tests_properties(LeidTest2_5 PROPERTIES
PASS_REGULAR_EXPRESSION "{}")

# LeidenTest3 ChooseRandomComm
add_test(LeidTest3_1 LeidenTests test3 ${TST_DIR}/test1.bin ${TST_DIR}/ChRandCommTest1.txt 0 1 3 4 4)
add_test(LeidTest3_2 LeidenTests test3 ${TST_DIR}/test2.bin ${TST_DIR}/SinglComm2.txt 1 4 8)
add_test(LeidTest3_3 LeidenTests test3 ${TST_DIR}/test3.bin ${TST_DIR}/SinglComm3.txt 2 4 6 9 8 13 0)
add_test(LeidTest3_4 LeidenTests test3 ${TST_DIR}/test4.bin ${TST_DIR}/SinglComm4.txt 2 6 0)
add_test(LeidTest3_5 LeidenTests test3 ${TST_DIR}/test5.bin ${TST_DIR}/SinglComm5.txt 3 6 3)

set_tests_properties(LeidTest3_1 LeidTest3_2 LeidTest3_3 LeidTest3_4 LeidTest3_5
PROPERTIES TIMEOUT ${LDN_TIMEOUT})
set_tests_properties(LeidTest3_1 PROPERTIES
PASS_REGULAR_EXPRESSION "P" FAIL_REGULAR_EXPRESSION "F")
set_tests_properties(LeidTest3_2 PROPERTIES
PASS_REGULAR_EXPRESSION "P" FAIL_REGULAR_EXPRESSION "F")
set_tests_properties(LeidTest3_3 PROPERTIES
PASS_REGULAR_EXPRESSION "P" FAIL_REGULAR_EXPRESSION "F")
set_tests_properties(LeidTest3_4 PROPERTIES
PASS_REGULAR_EXPRESSION "P" FAIL_REGULAR_EXPRESSION "F")
set_tests_properties(LeidTest3_5 PROPERTIES
PASS_REGULAR_EXPRESSION "P" FAIL_REGULAR_EXPRESSION "F")


# LeidenTest4 isInSinlgComm
add_test(LeidTest4_1 LeidenTests test4 ${TST_DIR}/test1.bin ${TST_DIR}/SinglComm1.txt 7 1 3)
add_test(LeidTest4_2 LeidenTests test4 ${TST_DIR}/test2.bin ${TST_DIR}/SinglComm2.txt 8 2 4)
add_test(LeidTest4_3 LeidenTests test4 ${TST_DIR}/test3.bin ${TST_DIR}/SinglComm3.txt 29 24 9)
add_test(LeidTest4_4 LeidenTests test4 ${TST_DIR}/test4.bin ${TST_DIR}/SinglComm4.txt 20 1 11)
add_test(LeidTest4_5 LeidenTests test4 ${TST_DIR}/test5.bin ${TST_DIR}/SinglComm5.txt 9 5 2)

set_tests_properties(LeidTest4_1 LeidTest4_2 LeidTest4_3 LeidTest4_4 LeidTest4_5
PROPERTIES TIMEOUT ${LDN_TIMEOUT})
set_tests_properties(LeidTest4_1 PROPERTIES
PASS_REGULAR_EXPRESSION " 0  1  0 ")
set_tests_properties(LeidTest4_2 PROPERTIES
PASS_REGULAR_EXPRESSION " 1  0  0 ")
set_tests_properties(LeidTest4_3 PROPERTIES
PASS_REGULAR_EXPRESSION " 1  0  0 ")
set_tests_properties(LeidTest4_4 PROPERTIES
PASS_REGULAR_EXPRESSION " 0  0  0 ")
set_tests_properties(LeidTest4_5 PROPERTIES
PASS_REGULAR_EXPRESSION " 1  0  0 ")


# LeidenTest5 wellConnComms
add_test(LeidTest5_1 LeidenTests test5 ${TST_DIR}/test1.bin ${TST_DIR}/SinglComm1.txt)
add_test(LeidTest5_2 LeidenTests test5 ${TST_DIR}/test2.bin ${TST_DIR}/SinglComm2.txt)
add_test(LeidTest5_3 LeidenTests test5 ${TST_DIR}/test3.bin ${TST_DIR}/SinglComm3.txt)
add_test(LeidTest5_4 LeidenTests test5 ${TST_DIR}/test4.bin ${TST_DIR}/SinglComm4.txt)
add_test(LeidTest5_5 LeidenTests test5 ${TST_DIR}/test5.bin ${TST_DIR}/SinglComm5.txt)

set_tests_properties(LeidTest5_1 LeidTest5_2 LeidTest5_3 LeidTest5_4 LeidTest5_5
PROPERTIES TIMEOUT ${LDN_TIMEOUT})

# PASS?


# LeidenTest6 refinePartition
add_test(LeidTest6_1 LeidenTests test6 ${TST_DIR}/test1.bin ${TST_DIR}/SinglComm1.txt)
add_test(LeidTest6_2 LeidenTests test6 ${TST_DIR}/test2.bin ${TST_DIR}/SinglComm2.txt)
add_test(LeidTest6_3 LeidenTests test6 ${TST_DIR}/test3.bin ${TST_DIR}/SinglComm3.txt)
add_test(LeidTest6_4 LeidenTests test6 ${TST_DIR}/test4.bin ${TST_DIR}/SinglComm4.txt)
add_test(LeidTest6_5 LeidenTests test6 ${TST_DIR}/test5.bin ${TST_DIR}/SinglComm5.txt)

set_tests_properties(LeidTest6_1 LeidTest6_2 LeidTest6_3 LeidTest6_4 LeidTest6_5
PROPERTIES TIMEOUT ${LDN_TIMEOUT})

# PASS?


# LeidenTest7 moveNodes
add_test(LeidTest7_1 LeidenTests test7 ${TST_DIR}/test1.bin ${TST_DIR}/SinglComm1.txt)
add_test(LeidTest7_2 LeidenTests test7 ${TST_DIR}/test2.bin ${TST_DIR}/SinglComm2.txt)
add_test(LeidTest7_3 LeidenTests test7 ${TST_DIR}/test3.bin ${TST_DIR}/SinglComm3.txt)
add_test(LeidTest7_4 LeidenTests test7 ${TST_DIR}/test4.bin ${TST_DIR}/SinglComm4.txt)
add_test(LeidTest7_5 LeidenTests test7 ${TST_DIR}/test5.bin ${TST_DIR}/SinglComm5.txt)

set_tests_properties(LeidTest7_1 LeidTest7_2 LeidTest7_3 LeidTest7_4 LeidTest7_5
PROPERTIES TIMEOUT ${LDN_TIMEOUT})

# PASS?


# LeidenTest8 maintain_partition()

# TODO


# LeidenTest9 GetLeidenPartitionOf()
set(LEIDEN_TIMEOUT 2)

add_test(LeidTest9_1 LeidenTests test9 ${TST_DIR}/test1.bin)
add_test(LeidTest9_2 LeidenTests test9 ${TST_DIR}/test2.bin)
add_test(LeidTest9_3 LeidenTests test9 ${TST_DIR}/test3.bin)
add_test(LeidTest9_4 LeidenTests test9 ${TST_DIR}/test4.bin)
add_test(LeidTest9_5 LeidenTests test9 ${TST_DIR}/test5.bin)

set_tests_properties(LeidTest9_1 LeidTest9_2 LeidTest9_3 LeidTest9_4 LeidTest9_5
PROPERTIES TIMEOUT ${LEIDEN_TIMEOUT})

# PASS?

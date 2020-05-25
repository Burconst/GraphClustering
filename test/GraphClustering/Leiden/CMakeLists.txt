
set(MULTIPLY_TIMEOUT 1)

# LeidenTest1 getMarkedNodes

add_executable(LeidenTest1 LeidenTest1.cpp)
target_link_libraries(LeidenTest1 GraphClustering)

add_test(Leid1Test1 LeidenTest1 ./TestData/test1.bin ./TestData/comm1.txt)
add_test(Leid1Test2 LeidenTest1 ./TestData/test2.bin ./TestData/comm2.txt)
# add_test(Leid1Test3 LeidenTest1 ./TestData/test3.bin ./TestData/comm3.txt)
add_test(Leid1Test4 LeidenTest1 ./TestData/test4.bin ./TestData/comm4.txt)
add_test(Leid1Test5 LeidenTest1 ./TestData/test5.bin ./TestData/comm5.txt)

set_tests_properties(Leid1Test1 Leid1Test2 Leid1Test4 Leid1Test5 # Leid1Test3
PROPERTIES TIMEOUT ${MULTIPLY_TIMEOUT})
set_tests_properties(Leid1Test1 PROPERTIES
PASS_REGULAR_EXPRESSION "{ 1  2  3  5  6 }")
set_tests_properties(Leid1Test2 PROPERTIES
PASS_REGULAR_EXPRESSION "{ 0  1  2  3  7 }")
# set_tests_properties(Leid1Test3 PROPERTIES
# PASS_REGULAR_EXPRESSION "{ 0  2  6  11  12  13  18  19  24  26  27  29  30 }")
set_tests_properties(Leid1Test4 PROPERTIES
PASS_REGULAR_EXPRESSION "{ 0  1  8  10  13  14  15  16  21 }")
set_tests_properties(Leid1Test5 PROPERTIES
PASS_REGULAR_EXPRESSION "{ 1  4  5  6  8  11 }")

# LeidenTest2 getWellConnectedNodes

add_executable(LeidenTest2 LeidenTest2.cpp)
target_link_libraries(LeidenTest2 GraphClustering)

add_test(Leid2Test1 LeidenTest2 ./TestData/test1.bin ./TestData/comm1.txt 0 1 2 4 8)
add_test(Leid2Test2 LeidenTest2 ./TestData/test2.bin ./TestData/comm2.txt 0 3 8 9)
add_test(Leid2Test3 LeidenTest2 ./TestData/test3.bin ./TestData/comm3.txt 0 3 4 5)
add_test(Leid2Test4 LeidenTest2 ./TestData/test4.bin ./TestData/comm4.txt 15 21 22 23)
add_test(Leid2Test5 LeidenTest2 ./TestData/test5.bin ./TestData/comm5.txt 2 3 4 6 7)

set_tests_properties(Leid2Test1 Leid2Test2 Leid2Test4 Leid2Test5 Leid2Test3
PROPERTIES TIMEOUT ${MULTIPLY_TIMEOUT})
set_tests_properties(Leid2Test1 PROPERTIES
PASS_REGULAR_EXPRESSION "{ 0 }")
set_tests_properties(Leid2Test2 PROPERTIES
PASS_REGULAR_EXPRESSION "{ 8 }")
set_tests_properties(Leid2Test3 PROPERTIES
PASS_REGULAR_EXPRESSION "{}")
set_tests_properties(Leid2Test4 PROPERTIES
PASS_REGULAR_EXPRESSION "{ 21 }")
set_tests_properties(Leid2Test5 PROPERTIES
PASS_REGULAR_EXPRESSION "{}")


# LeidenTest3 ChooseRandomComm

add_executable(LeidenTest3 LeidenTest3.cpp)
target_link_libraries(LeidenTest3 GraphClustering)

add_test(Leid3Test1 LeidenTest3 ./TestData/test1.bin ./TestData/ChRandCommTest1.txt 0 1 3 4 4)
add_test(Leid3Test2 LeidenTest3 ./TestData/test2.bin ./TestData/SinglComm2.txt 1 4 8)
add_test(Leid3Test3 LeidenTest3 ./TestData/test3.bin ./TestData/SinglComm3.txt 2 4 6 9 8 13 0)
add_test(Leid3Test4 LeidenTest3 ./TestData/test4.bin ./TestData/SinglComm4.txt 2 6 0)
add_test(Leid3Test5 LeidenTest3 ./TestData/test5.bin ./TestData/SinglComm5.txt 3 6 3)

set_tests_properties(Leid3Test1 Leid3Test2 Leid3Test4 Leid3Test5 Leid3Test3
PROPERTIES TIMEOUT ${MULTIPLY_TIMEOUT})
set_tests_properties(Leid3Test1 PROPERTIES
PASS_REGULAR_EXPRESSION "")



# LeidenTest4 isInSinlgComm

add_executable(LeidenTest4 LeidenTest4.cpp)
target_link_libraries(LeidenTest4 GraphClustering)

add_test(Leid4Test1 LeidenTest4 ./TestData/test1.bin ./TestData/SinglComm1.txt 7 1 3)
add_test(Leid4Test2 LeidenTest4 ./TestData/test2.bin ./TestData/SinglComm2.txt 8 2 4)
add_test(Leid4Test3 LeidenTest4 ./TestData/test3.bin ./TestData/SinglComm3.txt 29 24 9)
add_test(Leid4Test4 LeidenTest4 ./TestData/test4.bin ./TestData/SinglComm4.txt 20 1 11)
add_test(Leid4Test5 LeidenTest4 ./TestData/test5.bin ./TestData/SinglComm5.txt 9 5 2)

set_tests_properties(Leid4Test1 Leid4Test2 Leid4Test4 Leid4Test5 Leid4Test3
PROPERTIES TIMEOUT ${MULTIPLY_TIMEOUT})
set_tests_properties(Leid4Test1 PROPERTIES
PASS_REGULAR_EXPRESSION " 0  1  0 ")
set_tests_properties(Leid4Test2 PROPERTIES
PASS_REGULAR_EXPRESSION " 1  0  0 ")
set_tests_properties(Leid4Test3 PROPERTIES
PASS_REGULAR_EXPRESSION " 1  0  0 ")
set_tests_properties(Leid4Test4 PROPERTIES
PASS_REGULAR_EXPRESSION " 0  0  0 ")
set_tests_properties(Leid4Test5 PROPERTIES
PASS_REGULAR_EXPRESSION " 1  0  0 ")

# LeidenTest5 wellConnComms

add_executable(LeidenTest5 LeidenTest5.cpp)
target_link_libraries(LeidenTest5 GraphClustering)

add_test(Leid5Test1 LeidenTest5 ./TestData/test1.bin ./TestData/SinglComm1.txt)
add_test(Leid5Test2 LeidenTest5 ./TestData/test2.bin ./TestData/SinglComm2.txt)
add_test(Leid5Test3 LeidenTest5 ./TestData/test3.bin ./TestData/SinglComm3.txt)
add_test(Leid5Test4 LeidenTest5 ./TestData/test4.bin ./TestData/SinglComm4.txt)
add_test(Leid5Test5 LeidenTest5 ./TestData/test5.bin ./TestData/SinglComm5.txt)

set_tests_properties(Leid5Test1 Leid5Test2 Leid5Test4 Leid5Test5 Leid5Test3
PROPERTIES TIMEOUT ${MULTIPLY_TIMEOUT})

# LeidenTest6 wellConnComms

add_executable(LeidenTest6 LeidenTest6.cpp)
target_link_libraries(LeidenTest6 GraphClustering)

# LeidenTest7 refinePartition

add_executable(LeidenTest7 LeidenTest7.cpp)
target_link_libraries(LeidenTest7 GraphClustering)


# LeidenTest8 moveNodes

add_executable(LeidenTest8 LeidenTest8.cpp)
target_link_libraries(LeidenTest8 GraphClustering)

# LeidenTest8 maintain partition

add_executable(LeidenTest9 LeidenTest9.cpp)
target_link_libraries(LeidenTest9 GraphClustering)

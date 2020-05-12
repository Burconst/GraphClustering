# Test1 NeighComm
add_executable(PartitionTest1 PartitionTest1.cpp)
target_link_libraries(PartitionTest1 GraphClustering)

add_test(P1Test1 PartitionTest1 ./TestData/test1.bin ./TestData/comm1.txt 6 3 9)
add_test(P1Test2 PartitionTest1 ./TestData/test2.bin ./TestData/comm2.txt 7 5 3)
add_test(P1Test3 PartitionTest1 ./TestData/test3.bin ./TestData/comm3.txt 0 29 15)
add_test(P1Test4 PartitionTest1 ./TestData/test4.bin ./TestData/comm4.txt 0 8 10)
add_test(P1Test5 PartitionTest1 ./TestData/test5.bin ./TestData/comm5.txt 5 4 11)

set_tests_properties(P1Test1 PROPERTIES
PASS_REGULAR_EXPRESSION "{ 1  2 }{ 0  1  2 }{ 0 }")
set_tests_properties(P1Test2 PROPERTIES
PASS_REGULAR_EXPRESSION "{ 0  1 }{ 2 }{ 1  2 }")
set_tests_properties(P1Test3 PROPERTIES
PASS_REGULAR_EXPRESSION "{ 0  1  2  3  4 }{ 0  4 }{ 3 }")
set_tests_properties(P1Test4 PROPERTIES
PASS_REGULAR_EXPRESSION "{ 0  2  3 }{ 0  1 }{ 1  2  3 }")
set_tests_properties(P1Test5 PROPERTIES
PASS_REGULAR_EXPRESSION "{ 0  2  3 }{ 0  1  2 }{ 0  2  3 }")

# Test2 getComm
add_executable(PartitionTest2 PartitionTest2.cpp)
target_link_libraries(PartitionTest2 GraphClustering)

add_test(P2Test1 PartitionTest2 ./TestData/test1.bin ./TestData/comm1.txt)
add_test(P2Test2 PartitionTest2 ./TestData/test2.bin ./TestData/comm2.txt)
add_test(P2Test3 PartitionTest2 ./TestData/test3.bin ./TestData/comm3.txt)
add_test(P2Test4 PartitionTest2 ./TestData/test4.bin ./TestData/comm4.txt)
add_test(P2Test5 PartitionTest2 ./TestData/test5.bin ./TestData/comm5.txt)

set_tests_properties(P2Test1 PROPERTIES
PASS_REGULAR_EXPRESSION "{ 0  1  2 }")
set_tests_properties(P2Test2 PROPERTIES
PASS_REGULAR_EXPRESSION "{ 0  1  2 }")
set_tests_properties(P2Test3 PROPERTIES
PASS_REGULAR_EXPRESSION "{ 0  1  2  3  4 }") 
set_tests_properties(P2Test4 PROPERTIES
PASS_REGULAR_EXPRESSION "{ 0  1  2  3 }")
set_tests_properties(P2Test5 PROPERTIES
PASS_REGULAR_EXPRESSION "{ 0  1  2  3 }")

# PartitionTest3 operator ==

add_executable(PartitionTest3 PartitionTest3.cpp)
target_link_libraries(PartitionTest3 GraphClustering)

add_test(P3Test1 PartitionTest3 ./TestData/test1.bin ./TestData/comm1.txt ./TestData/test1.bin ./TestData/comm1.txt)
add_test(P3Test2 PartitionTest3 ./TestData/test1.bin ./TestData/comm1.txt ./TestData/test1.bin ./TestData/notcomm1.txt)
add_test(P3Test3 PartitionTest3 ./TestData/test1.bin ./TestData/comm1.txt ./TestData/test2.bin ./TestData/comm2.txt)

set_tests_properties(P3Test1 PROPERTIES
PASS_REGULAR_EXPRESSION "Equal")
set_tests_properties(P3Test2 PROPERTIES
PASS_REGULAR_EXPRESSION "Not Equal")
set_tests_properties(P3Test3 PROPERTIES
PASS_REGULAR_EXPRESSION "Not Equal")

# PartitionTest4 copy operator

add_executable(PartitionTest4 PartitionTest4.cpp)
target_link_libraries(PartitionTest4 GraphClustering)

add_test(P4Test1 PartitionTest4 ./TestData/test1.bin ./TestData/comm1.txt)
add_test(P4Test2 PartitionTest4 ./TestData/test2.bin ./TestData/comm2.txt)
add_test(P4Test3 PartitionTest4 ./TestData/test3.bin ./TestData/comm3.txt)
add_test(P4Test4 PartitionTest4 ./TestData/test4.bin ./TestData/comm4.txt)
add_test(P4Test5 PartitionTest4 ./TestData/test5.bin ./TestData/comm5.txt)

set_tests_properties(P4Test1 PROPERTIES
PASS_REGULAR_EXPRESSION "Equal")
set_tests_properties(P4Test2 PROPERTIES
PASS_REGULAR_EXPRESSION "Equal")
set_tests_properties(P4Test3 PROPERTIES
PASS_REGULAR_EXPRESSION "Equal")
set_tests_properties(P4Test4 PROPERTIES
PASS_REGULAR_EXPRESSION "Equal")
set_tests_properties(P4Test5 PROPERTIES
PASS_REGULAR_EXPRESSION "Equal")


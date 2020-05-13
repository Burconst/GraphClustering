# CMake generated Testfile for 
# Source directory: /run/media/konstantin/NameD/Home/git/GraphClusteringLib/test/GraphClustering/Leiden
# Build directory: /run/media/konstantin/NameD/Home/git/GraphClusteringLib/test/GraphClustering/Leiden
# 
# This file includes the relevant testing commands required for 
# testing this directory and lists subdirectories to be tested as well.
add_test(Leid1Test1 "LeidenTest1" "./TestData/test1.bin" "./TestData/comm1.txt")
set_tests_properties(Leid1Test1 PROPERTIES  PASS_REGULAR_EXPRESSION "{ 1  2  3  5  6 }" TIMEOUT "1")
add_test(Leid1Test2 "LeidenTest1" "./TestData/test2.bin" "./TestData/comm2.txt")
set_tests_properties(Leid1Test2 PROPERTIES  PASS_REGULAR_EXPRESSION "{ 0  1  2  3  7 }" TIMEOUT "1")
add_test(Leid1Test4 "LeidenTest1" "./TestData/test4.bin" "./TestData/comm4.txt")
set_tests_properties(Leid1Test4 PROPERTIES  PASS_REGULAR_EXPRESSION "{ 0  1  8  10  13  14  15  16  21 }" TIMEOUT "1")
add_test(Leid1Test5 "LeidenTest1" "./TestData/test5.bin" "./TestData/comm5.txt")
set_tests_properties(Leid1Test5 PROPERTIES  PASS_REGULAR_EXPRESSION "{ 1  4  5  6  8  11 }" TIMEOUT "1")
add_test(Leid2Test1 "LeidenTest2" "./TestData/test1.bin" "./TestData/comm1.txt" "0" "1" "2" "4" "8")
set_tests_properties(Leid2Test1 PROPERTIES  PASS_REGULAR_EXPRESSION "{ 0 }" TIMEOUT "1")
add_test(Leid2Test2 "LeidenTest2" "./TestData/test2.bin" "./TestData/comm2.txt" "0" "3" "8" "9")
set_tests_properties(Leid2Test2 PROPERTIES  PASS_REGULAR_EXPRESSION "{ 8 }" TIMEOUT "1")
add_test(Leid2Test3 "LeidenTest2" "./TestData/test3.bin" "./TestData/comm3.txt" "0" "3" "4" "5")
set_tests_properties(Leid2Test3 PROPERTIES  PASS_REGULAR_EXPRESSION "{}" TIMEOUT "1")
add_test(Leid2Test4 "LeidenTest2" "./TestData/test4.bin" "./TestData/comm4.txt" "15" "21" "22" "23")
set_tests_properties(Leid2Test4 PROPERTIES  PASS_REGULAR_EXPRESSION "{ 21 }" TIMEOUT "1")
add_test(Leid2Test5 "LeidenTest2" "./TestData/test5.bin" "./TestData/comm5.txt" "2" "3" "4" "6" "7")
set_tests_properties(Leid2Test5 PROPERTIES  PASS_REGULAR_EXPRESSION "{}" TIMEOUT "1")

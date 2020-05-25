
set(MULTIPLY_TIMEOUT 1)

# LeidenTest1 getMarkedNodes

add_executable(LouvainTest1 LouvainTest1.cpp)
target_link_libraries(LouvainTest1 GraphClustering)

# add_test(Leid1Test1 LeidenTest1 ./TestData/test1.bin ./TestData/comm1.txt)
# add_test(Leid1Test2 LeidenTest1 ./TestData/test2.bin ./TestData/comm2.txt)
# # add_test(Leid1Test3 LeidenTest1 ./TestData/test3.bin ./TestData/comm3.txt)
# add_test(Leid1Test4 LeidenTest1 ./TestData/test4.bin ./TestData/comm4.txt)
# add_test(Leid1Test5 LeidenTest1 ./TestData/test5.bin ./TestData/comm5.txt)

# set_tests_properties(Leid1Test1 Leid1Test2 Leid1Test4 Leid1Test5 # Leid1Test3
# PROPERTIES TIMEOUT ${MULTIPLY_TIMEOUT})
# set_tests_properties(Leid1Test1 PROPERTIES
# PASS_REGULAR_EXPRESSION "{ 1  2  3  5  6 }")
# set_tests_properties(Leid1Test2 PROPERTIES
# PASS_REGULAR_EXPRESSION "{ 0  1  2  3  7 }")
# # set_tests_properties(Leid1Test3 PROPERTIES
# # PASS_REGULAR_EXPRESSION "{ 0  2  6  11  12  13  18  19  24  26  27  29  30 }")
# set_tests_properties(Leid1Test4 PROPERTIES
# PASS_REGULAR_EXPRESSION "{ 0  1  8  10  13  14  15  16  21 }")
# set_tests_properties(Leid1Test5 PROPERTIES
# PASS_REGULAR_EXPRESSION "{ 1  4  5  6  8  11 }")
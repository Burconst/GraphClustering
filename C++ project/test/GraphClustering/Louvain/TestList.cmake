set(TST_DIR "../TestData")

set(LOUV_TIMEOUT 1)

add_test(LouvTest1_1 LouvainTests test1 ${TST_DIR}/test1.bin)
add_test(LouvTest1_2 LouvainTests test1 ${TST_DIR}/test2.bin)
add_test(LouvTest1_3 LouvainTests test1 ${TST_DIR}/test3.bin)
add_test(LouvTest1_4 LouvainTests test1 ${TST_DIR}/test4.bin)
add_test(LouvTest1_5 LouvainTests test1 ${TST_DIR}/test5.bin)

set_tests_properties(LouvTest1_1 LouvTest1_2 LouvTest1_3 LouvTest1_4 LouvTest1_5
PROPERTIES TIMEOUT ${LOUV_TIMEOUT})
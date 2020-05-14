# CMAKE generated file: DO NOT EDIT!
# Generated by "Unix Makefiles" Generator, CMake Version 3.12

# Default target executed when no arguments are given to make.
default_target: all

.PHONY : default_target

# Allow only one "make -f Makefile2" at a time, but pass parallelism.
.NOTPARALLEL:


#=============================================================================
# Special targets provided by cmake.

# Disable implicit rules so canonical targets will work.
.SUFFIXES:


# Remove some rules from gmake that .SUFFIXES does not remove.
SUFFIXES =

.SUFFIXES: .hpux_make_needs_suffix_list


# Suppress display of executed commands.
$(VERBOSE).SILENT:


# A target that is always out of date.
cmake_force:

.PHONY : cmake_force

#=============================================================================
# Set environment variables for the build.

# The shell in which to execute make rules.
SHELL = /bin/sh

# The CMake executable.
CMAKE_COMMAND = /usr/local/bin/cmake

# The command to remove a file.
RM = /usr/local/bin/cmake -E remove -f

# Escaping for special characters.
EQUALS = =

# The top-level source directory on which CMake was run.
CMAKE_SOURCE_DIR = /run/media/konstantin/NameD/Home/git/GraphClusteringLib

# The top-level build directory on which CMake was run.
CMAKE_BINARY_DIR = /run/media/konstantin/NameD/Home/git/GraphClusteringLib

#=============================================================================
# Targets provided globally by CMake.

# Special rule for the target rebuild_cache
rebuild_cache:
	@$(CMAKE_COMMAND) -E cmake_echo_color --switch=$(COLOR) --cyan "Running CMake to regenerate build system..."
	/usr/local/bin/cmake -H$(CMAKE_SOURCE_DIR) -B$(CMAKE_BINARY_DIR)
.PHONY : rebuild_cache

# Special rule for the target rebuild_cache
rebuild_cache/fast: rebuild_cache

.PHONY : rebuild_cache/fast

# Special rule for the target edit_cache
edit_cache:
	@$(CMAKE_COMMAND) -E cmake_echo_color --switch=$(COLOR) --cyan "Running CMake cache editor..."
	/usr/local/bin/ccmake -H$(CMAKE_SOURCE_DIR) -B$(CMAKE_BINARY_DIR)
.PHONY : edit_cache

# Special rule for the target edit_cache
edit_cache/fast: edit_cache

.PHONY : edit_cache/fast

# The main all target
all: cmake_check_build_system
	$(CMAKE_COMMAND) -E cmake_progress_start /run/media/konstantin/NameD/Home/git/GraphClusteringLib/CMakeFiles /run/media/konstantin/NameD/Home/git/GraphClusteringLib/CMakeFiles/progress.marks
	$(MAKE) -f CMakeFiles/Makefile2 all
	$(CMAKE_COMMAND) -E cmake_progress_start /run/media/konstantin/NameD/Home/git/GraphClusteringLib/CMakeFiles 0
.PHONY : all

# The main clean target
clean:
	$(MAKE) -f CMakeFiles/Makefile2 clean
.PHONY : clean

# The main clean target
clean/fast: clean

.PHONY : clean/fast

# Prepare targets for installation.
preinstall: all
	$(MAKE) -f CMakeFiles/Makefile2 preinstall
.PHONY : preinstall

# Prepare targets for installation.
preinstall/fast:
	$(MAKE) -f CMakeFiles/Makefile2 preinstall
.PHONY : preinstall/fast

# clear depends
depend:
	$(CMAKE_COMMAND) -H$(CMAKE_SOURCE_DIR) -B$(CMAKE_BINARY_DIR) --check-build-system CMakeFiles/Makefile.cmake 1
.PHONY : depend

#=============================================================================
# Target rules for targets named GraphClustering

# Build rule for target.
GraphClustering: cmake_check_build_system
	$(MAKE) -f CMakeFiles/Makefile2 GraphClustering
.PHONY : GraphClustering

# fast build rule for target.
GraphClustering/fast:
	$(MAKE) -f src/CMakeFiles/GraphClustering.dir/build.make src/CMakeFiles/GraphClustering.dir/build
.PHONY : GraphClustering/fast

#=============================================================================
# Target rules for targets named GraphTest6

# Build rule for target.
GraphTest6: cmake_check_build_system
	$(MAKE) -f CMakeFiles/Makefile2 GraphTest6
.PHONY : GraphTest6

# fast build rule for target.
GraphTest6/fast:
	$(MAKE) -f test/Graph/CMakeFiles/GraphTest6.dir/build.make test/Graph/CMakeFiles/GraphTest6.dir/build
.PHONY : GraphTest6/fast

#=============================================================================
# Target rules for targets named GraphTest5

# Build rule for target.
GraphTest5: cmake_check_build_system
	$(MAKE) -f CMakeFiles/Makefile2 GraphTest5
.PHONY : GraphTest5

# fast build rule for target.
GraphTest5/fast:
	$(MAKE) -f test/Graph/CMakeFiles/GraphTest5.dir/build.make test/Graph/CMakeFiles/GraphTest5.dir/build
.PHONY : GraphTest5/fast

#=============================================================================
# Target rules for targets named GraphTest7

# Build rule for target.
GraphTest7: cmake_check_build_system
	$(MAKE) -f CMakeFiles/Makefile2 GraphTest7
.PHONY : GraphTest7

# fast build rule for target.
GraphTest7/fast:
	$(MAKE) -f test/Graph/CMakeFiles/GraphTest7.dir/build.make test/Graph/CMakeFiles/GraphTest7.dir/build
.PHONY : GraphTest7/fast

#=============================================================================
# Target rules for targets named GraphTest1

# Build rule for target.
GraphTest1: cmake_check_build_system
	$(MAKE) -f CMakeFiles/Makefile2 GraphTest1
.PHONY : GraphTest1

# fast build rule for target.
GraphTest1/fast:
	$(MAKE) -f test/Graph/CMakeFiles/GraphTest1.dir/build.make test/Graph/CMakeFiles/GraphTest1.dir/build
.PHONY : GraphTest1/fast

#=============================================================================
# Target rules for targets named GraphTest2

# Build rule for target.
GraphTest2: cmake_check_build_system
	$(MAKE) -f CMakeFiles/Makefile2 GraphTest2
.PHONY : GraphTest2

# fast build rule for target.
GraphTest2/fast:
	$(MAKE) -f test/Graph/CMakeFiles/GraphTest2.dir/build.make test/Graph/CMakeFiles/GraphTest2.dir/build
.PHONY : GraphTest2/fast

#=============================================================================
# Target rules for targets named GraphTest3

# Build rule for target.
GraphTest3: cmake_check_build_system
	$(MAKE) -f CMakeFiles/Makefile2 GraphTest3
.PHONY : GraphTest3

# fast build rule for target.
GraphTest3/fast:
	$(MAKE) -f test/Graph/CMakeFiles/GraphTest3.dir/build.make test/Graph/CMakeFiles/GraphTest3.dir/build
.PHONY : GraphTest3/fast

#=============================================================================
# Target rules for targets named GraphTest4

# Build rule for target.
GraphTest4: cmake_check_build_system
	$(MAKE) -f CMakeFiles/Makefile2 GraphTest4
.PHONY : GraphTest4

# fast build rule for target.
GraphTest4/fast:
	$(MAKE) -f test/Graph/CMakeFiles/GraphTest4.dir/build.make test/Graph/CMakeFiles/GraphTest4.dir/build
.PHONY : GraphTest4/fast

#=============================================================================
# Target rules for targets named PartitionTest5

# Build rule for target.
PartitionTest5: cmake_check_build_system
	$(MAKE) -f CMakeFiles/Makefile2 PartitionTest5
.PHONY : PartitionTest5

# fast build rule for target.
PartitionTest5/fast:
	$(MAKE) -f test/Partition/CMakeFiles/PartitionTest5.dir/build.make test/Partition/CMakeFiles/PartitionTest5.dir/build
.PHONY : PartitionTest5/fast

#=============================================================================
# Target rules for targets named PartitionTest1

# Build rule for target.
PartitionTest1: cmake_check_build_system
	$(MAKE) -f CMakeFiles/Makefile2 PartitionTest1
.PHONY : PartitionTest1

# fast build rule for target.
PartitionTest1/fast:
	$(MAKE) -f test/Partition/CMakeFiles/PartitionTest1.dir/build.make test/Partition/CMakeFiles/PartitionTest1.dir/build
.PHONY : PartitionTest1/fast

#=============================================================================
# Target rules for targets named PartitionTest4

# Build rule for target.
PartitionTest4: cmake_check_build_system
	$(MAKE) -f CMakeFiles/Makefile2 PartitionTest4
.PHONY : PartitionTest4

# fast build rule for target.
PartitionTest4/fast:
	$(MAKE) -f test/Partition/CMakeFiles/PartitionTest4.dir/build.make test/Partition/CMakeFiles/PartitionTest4.dir/build
.PHONY : PartitionTest4/fast

#=============================================================================
# Target rules for targets named PartitionTest6

# Build rule for target.
PartitionTest6: cmake_check_build_system
	$(MAKE) -f CMakeFiles/Makefile2 PartitionTest6
.PHONY : PartitionTest6

# fast build rule for target.
PartitionTest6/fast:
	$(MAKE) -f test/Partition/CMakeFiles/PartitionTest6.dir/build.make test/Partition/CMakeFiles/PartitionTest6.dir/build
.PHONY : PartitionTest6/fast

#=============================================================================
# Target rules for targets named PartitionTest2

# Build rule for target.
PartitionTest2: cmake_check_build_system
	$(MAKE) -f CMakeFiles/Makefile2 PartitionTest2
.PHONY : PartitionTest2

# fast build rule for target.
PartitionTest2/fast:
	$(MAKE) -f test/Partition/CMakeFiles/PartitionTest2.dir/build.make test/Partition/CMakeFiles/PartitionTest2.dir/build
.PHONY : PartitionTest2/fast

#=============================================================================
# Target rules for targets named PartitionTest3

# Build rule for target.
PartitionTest3: cmake_check_build_system
	$(MAKE) -f CMakeFiles/Makefile2 PartitionTest3
.PHONY : PartitionTest3

# fast build rule for target.
PartitionTest3/fast:
	$(MAKE) -f test/Partition/CMakeFiles/PartitionTest3.dir/build.make test/Partition/CMakeFiles/PartitionTest3.dir/build
.PHONY : PartitionTest3/fast

#=============================================================================
# Target rules for targets named LeidenTest6

# Build rule for target.
LeidenTest6: cmake_check_build_system
	$(MAKE) -f CMakeFiles/Makefile2 LeidenTest6
.PHONY : LeidenTest6

# fast build rule for target.
LeidenTest6/fast:
	$(MAKE) -f test/GraphClustering/Leiden/CMakeFiles/LeidenTest6.dir/build.make test/GraphClustering/Leiden/CMakeFiles/LeidenTest6.dir/build
.PHONY : LeidenTest6/fast

#=============================================================================
# Target rules for targets named LeidenTest5

# Build rule for target.
LeidenTest5: cmake_check_build_system
	$(MAKE) -f CMakeFiles/Makefile2 LeidenTest5
.PHONY : LeidenTest5

# fast build rule for target.
LeidenTest5/fast:
	$(MAKE) -f test/GraphClustering/Leiden/CMakeFiles/LeidenTest5.dir/build.make test/GraphClustering/Leiden/CMakeFiles/LeidenTest5.dir/build
.PHONY : LeidenTest5/fast

#=============================================================================
# Target rules for targets named LeidenTest1

# Build rule for target.
LeidenTest1: cmake_check_build_system
	$(MAKE) -f CMakeFiles/Makefile2 LeidenTest1
.PHONY : LeidenTest1

# fast build rule for target.
LeidenTest1/fast:
	$(MAKE) -f test/GraphClustering/Leiden/CMakeFiles/LeidenTest1.dir/build.make test/GraphClustering/Leiden/CMakeFiles/LeidenTest1.dir/build
.PHONY : LeidenTest1/fast

#=============================================================================
# Target rules for targets named LeidenTest3

# Build rule for target.
LeidenTest3: cmake_check_build_system
	$(MAKE) -f CMakeFiles/Makefile2 LeidenTest3
.PHONY : LeidenTest3

# fast build rule for target.
LeidenTest3/fast:
	$(MAKE) -f test/GraphClustering/Leiden/CMakeFiles/LeidenTest3.dir/build.make test/GraphClustering/Leiden/CMakeFiles/LeidenTest3.dir/build
.PHONY : LeidenTest3/fast

#=============================================================================
# Target rules for targets named LeidenTest7

# Build rule for target.
LeidenTest7: cmake_check_build_system
	$(MAKE) -f CMakeFiles/Makefile2 LeidenTest7
.PHONY : LeidenTest7

# fast build rule for target.
LeidenTest7/fast:
	$(MAKE) -f test/GraphClustering/Leiden/CMakeFiles/LeidenTest7.dir/build.make test/GraphClustering/Leiden/CMakeFiles/LeidenTest7.dir/build
.PHONY : LeidenTest7/fast

#=============================================================================
# Target rules for targets named LeidenTest2

# Build rule for target.
LeidenTest2: cmake_check_build_system
	$(MAKE) -f CMakeFiles/Makefile2 LeidenTest2
.PHONY : LeidenTest2

# fast build rule for target.
LeidenTest2/fast:
	$(MAKE) -f test/GraphClustering/Leiden/CMakeFiles/LeidenTest2.dir/build.make test/GraphClustering/Leiden/CMakeFiles/LeidenTest2.dir/build
.PHONY : LeidenTest2/fast

#=============================================================================
# Target rules for targets named LeidenTest8

# Build rule for target.
LeidenTest8: cmake_check_build_system
	$(MAKE) -f CMakeFiles/Makefile2 LeidenTest8
.PHONY : LeidenTest8

# fast build rule for target.
LeidenTest8/fast:
	$(MAKE) -f test/GraphClustering/Leiden/CMakeFiles/LeidenTest8.dir/build.make test/GraphClustering/Leiden/CMakeFiles/LeidenTest8.dir/build
.PHONY : LeidenTest8/fast

#=============================================================================
# Target rules for targets named LeidenTest4

# Build rule for target.
LeidenTest4: cmake_check_build_system
	$(MAKE) -f CMakeFiles/Makefile2 LeidenTest4
.PHONY : LeidenTest4

# fast build rule for target.
LeidenTest4/fast:
	$(MAKE) -f test/GraphClustering/Leiden/CMakeFiles/LeidenTest4.dir/build.make test/GraphClustering/Leiden/CMakeFiles/LeidenTest4.dir/build
.PHONY : LeidenTest4/fast

# Help Target
help:
	@echo "The following are some of the valid targets for this Makefile:"
	@echo "... all (the default if no target is provided)"
	@echo "... clean"
	@echo "... depend"
	@echo "... rebuild_cache"
	@echo "... edit_cache"
	@echo "... GraphClustering"
	@echo "... GraphTest6"
	@echo "... GraphTest5"
	@echo "... GraphTest7"
	@echo "... GraphTest1"
	@echo "... GraphTest2"
	@echo "... GraphTest3"
	@echo "... GraphTest4"
	@echo "... PartitionTest5"
	@echo "... PartitionTest1"
	@echo "... PartitionTest4"
	@echo "... PartitionTest6"
	@echo "... PartitionTest2"
	@echo "... PartitionTest3"
	@echo "... LeidenTest6"
	@echo "... LeidenTest5"
	@echo "... LeidenTest1"
	@echo "... LeidenTest3"
	@echo "... LeidenTest7"
	@echo "... LeidenTest2"
	@echo "... LeidenTest8"
	@echo "... LeidenTest4"
.PHONY : help



#=============================================================================
# Special targets to cleanup operation of make.

# Special rule to run CMake to check the build system integrity.
# No rule that depends on this can have commands that come from listfiles
# because they might be regenerated.
cmake_check_build_system:
	$(CMAKE_COMMAND) -H$(CMAKE_SOURCE_DIR) -B$(CMAKE_BINARY_DIR) --check-build-system CMakeFiles/Makefile.cmake 0
.PHONY : cmake_check_build_system


# CMAKE generated file: DO NOT EDIT!
# Generated by "Unix Makefiles" Generator, CMake Version 3.12

# Delete rule output on recipe failure.
.DELETE_ON_ERROR:


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

# Include any dependencies generated for this target.
include test/Partition/CMakeFiles/PartitionTest6.dir/depend.make

# Include the progress variables for this target.
include test/Partition/CMakeFiles/PartitionTest6.dir/progress.make

# Include the compile flags for this target's objects.
include test/Partition/CMakeFiles/PartitionTest6.dir/flags.make

test/Partition/CMakeFiles/PartitionTest6.dir/PartitionTest6.cpp.o: test/Partition/CMakeFiles/PartitionTest6.dir/flags.make
test/Partition/CMakeFiles/PartitionTest6.dir/PartitionTest6.cpp.o: test/Partition/PartitionTest6.cpp
	@$(CMAKE_COMMAND) -E cmake_echo_color --switch=$(COLOR) --green --progress-dir=/run/media/konstantin/NameD/Home/git/GraphClusteringLib/CMakeFiles --progress-num=$(CMAKE_PROGRESS_1) "Building CXX object test/Partition/CMakeFiles/PartitionTest6.dir/PartitionTest6.cpp.o"
	cd /run/media/konstantin/NameD/Home/git/GraphClusteringLib/test/Partition && /usr/bin/c++  $(CXX_DEFINES) $(CXX_INCLUDES) $(CXX_FLAGS) -o CMakeFiles/PartitionTest6.dir/PartitionTest6.cpp.o -c /run/media/konstantin/NameD/Home/git/GraphClusteringLib/test/Partition/PartitionTest6.cpp

test/Partition/CMakeFiles/PartitionTest6.dir/PartitionTest6.cpp.i: cmake_force
	@$(CMAKE_COMMAND) -E cmake_echo_color --switch=$(COLOR) --green "Preprocessing CXX source to CMakeFiles/PartitionTest6.dir/PartitionTest6.cpp.i"
	cd /run/media/konstantin/NameD/Home/git/GraphClusteringLib/test/Partition && /usr/bin/c++ $(CXX_DEFINES) $(CXX_INCLUDES) $(CXX_FLAGS) -E /run/media/konstantin/NameD/Home/git/GraphClusteringLib/test/Partition/PartitionTest6.cpp > CMakeFiles/PartitionTest6.dir/PartitionTest6.cpp.i

test/Partition/CMakeFiles/PartitionTest6.dir/PartitionTest6.cpp.s: cmake_force
	@$(CMAKE_COMMAND) -E cmake_echo_color --switch=$(COLOR) --green "Compiling CXX source to assembly CMakeFiles/PartitionTest6.dir/PartitionTest6.cpp.s"
	cd /run/media/konstantin/NameD/Home/git/GraphClusteringLib/test/Partition && /usr/bin/c++ $(CXX_DEFINES) $(CXX_INCLUDES) $(CXX_FLAGS) -S /run/media/konstantin/NameD/Home/git/GraphClusteringLib/test/Partition/PartitionTest6.cpp -o CMakeFiles/PartitionTest6.dir/PartitionTest6.cpp.s

# Object files for target PartitionTest6
PartitionTest6_OBJECTS = \
"CMakeFiles/PartitionTest6.dir/PartitionTest6.cpp.o"

# External object files for target PartitionTest6
PartitionTest6_EXTERNAL_OBJECTS =

test/Partition/PartitionTest6: test/Partition/CMakeFiles/PartitionTest6.dir/PartitionTest6.cpp.o
test/Partition/PartitionTest6: test/Partition/CMakeFiles/PartitionTest6.dir/build.make
test/Partition/PartitionTest6: src/libGraphClustering.a
test/Partition/PartitionTest6: test/Partition/CMakeFiles/PartitionTest6.dir/link.txt
	@$(CMAKE_COMMAND) -E cmake_echo_color --switch=$(COLOR) --green --bold --progress-dir=/run/media/konstantin/NameD/Home/git/GraphClusteringLib/CMakeFiles --progress-num=$(CMAKE_PROGRESS_2) "Linking CXX executable PartitionTest6"
	cd /run/media/konstantin/NameD/Home/git/GraphClusteringLib/test/Partition && $(CMAKE_COMMAND) -E cmake_link_script CMakeFiles/PartitionTest6.dir/link.txt --verbose=$(VERBOSE)

# Rule to build all files generated by this target.
test/Partition/CMakeFiles/PartitionTest6.dir/build: test/Partition/PartitionTest6

.PHONY : test/Partition/CMakeFiles/PartitionTest6.dir/build

test/Partition/CMakeFiles/PartitionTest6.dir/clean:
	cd /run/media/konstantin/NameD/Home/git/GraphClusteringLib/test/Partition && $(CMAKE_COMMAND) -P CMakeFiles/PartitionTest6.dir/cmake_clean.cmake
.PHONY : test/Partition/CMakeFiles/PartitionTest6.dir/clean

test/Partition/CMakeFiles/PartitionTest6.dir/depend:
	cd /run/media/konstantin/NameD/Home/git/GraphClusteringLib && $(CMAKE_COMMAND) -E cmake_depends "Unix Makefiles" /run/media/konstantin/NameD/Home/git/GraphClusteringLib /run/media/konstantin/NameD/Home/git/GraphClusteringLib/test/Partition /run/media/konstantin/NameD/Home/git/GraphClusteringLib /run/media/konstantin/NameD/Home/git/GraphClusteringLib/test/Partition /run/media/konstantin/NameD/Home/git/GraphClusteringLib/test/Partition/CMakeFiles/PartitionTest6.dir/DependInfo.cmake --color=$(COLOR)
.PHONY : test/Partition/CMakeFiles/PartitionTest6.dir/depend


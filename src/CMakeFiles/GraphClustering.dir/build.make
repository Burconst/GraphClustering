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
include src/CMakeFiles/GraphClustering.dir/depend.make

# Include the progress variables for this target.
include src/CMakeFiles/GraphClustering.dir/progress.make

# Include the compile flags for this target's objects.
include src/CMakeFiles/GraphClustering.dir/flags.make

src/CMakeFiles/GraphClustering.dir/GraphBinary.cpp.o: src/CMakeFiles/GraphClustering.dir/flags.make
src/CMakeFiles/GraphClustering.dir/GraphBinary.cpp.o: src/GraphBinary.cpp
	@$(CMAKE_COMMAND) -E cmake_echo_color --switch=$(COLOR) --green --progress-dir=/run/media/konstantin/NameD/Home/git/GraphClusteringLib/CMakeFiles --progress-num=$(CMAKE_PROGRESS_1) "Building CXX object src/CMakeFiles/GraphClustering.dir/GraphBinary.cpp.o"
	cd /run/media/konstantin/NameD/Home/git/GraphClusteringLib/src && /usr/bin/c++  $(CXX_DEFINES) $(CXX_INCLUDES) $(CXX_FLAGS) -o CMakeFiles/GraphClustering.dir/GraphBinary.cpp.o -c /run/media/konstantin/NameD/Home/git/GraphClusteringLib/src/GraphBinary.cpp

src/CMakeFiles/GraphClustering.dir/GraphBinary.cpp.i: cmake_force
	@$(CMAKE_COMMAND) -E cmake_echo_color --switch=$(COLOR) --green "Preprocessing CXX source to CMakeFiles/GraphClustering.dir/GraphBinary.cpp.i"
	cd /run/media/konstantin/NameD/Home/git/GraphClusteringLib/src && /usr/bin/c++ $(CXX_DEFINES) $(CXX_INCLUDES) $(CXX_FLAGS) -E /run/media/konstantin/NameD/Home/git/GraphClusteringLib/src/GraphBinary.cpp > CMakeFiles/GraphClustering.dir/GraphBinary.cpp.i

src/CMakeFiles/GraphClustering.dir/GraphBinary.cpp.s: cmake_force
	@$(CMAKE_COMMAND) -E cmake_echo_color --switch=$(COLOR) --green "Compiling CXX source to assembly CMakeFiles/GraphClustering.dir/GraphBinary.cpp.s"
	cd /run/media/konstantin/NameD/Home/git/GraphClusteringLib/src && /usr/bin/c++ $(CXX_DEFINES) $(CXX_INCLUDES) $(CXX_FLAGS) -S /run/media/konstantin/NameD/Home/git/GraphClusteringLib/src/GraphBinary.cpp -o CMakeFiles/GraphClustering.dir/GraphBinary.cpp.s

# Object files for target GraphClustering
GraphClustering_OBJECTS = \
"CMakeFiles/GraphClustering.dir/GraphBinary.cpp.o"

# External object files for target GraphClustering
GraphClustering_EXTERNAL_OBJECTS =

src/libGraphClustering.a: src/CMakeFiles/GraphClustering.dir/GraphBinary.cpp.o
src/libGraphClustering.a: src/CMakeFiles/GraphClustering.dir/build.make
src/libGraphClustering.a: src/CMakeFiles/GraphClustering.dir/link.txt
	@$(CMAKE_COMMAND) -E cmake_echo_color --switch=$(COLOR) --green --bold --progress-dir=/run/media/konstantin/NameD/Home/git/GraphClusteringLib/CMakeFiles --progress-num=$(CMAKE_PROGRESS_2) "Linking CXX static library libGraphClustering.a"
	cd /run/media/konstantin/NameD/Home/git/GraphClusteringLib/src && $(CMAKE_COMMAND) -P CMakeFiles/GraphClustering.dir/cmake_clean_target.cmake
	cd /run/media/konstantin/NameD/Home/git/GraphClusteringLib/src && $(CMAKE_COMMAND) -E cmake_link_script CMakeFiles/GraphClustering.dir/link.txt --verbose=$(VERBOSE)

# Rule to build all files generated by this target.
src/CMakeFiles/GraphClustering.dir/build: src/libGraphClustering.a

.PHONY : src/CMakeFiles/GraphClustering.dir/build

src/CMakeFiles/GraphClustering.dir/clean:
	cd /run/media/konstantin/NameD/Home/git/GraphClusteringLib/src && $(CMAKE_COMMAND) -P CMakeFiles/GraphClustering.dir/cmake_clean.cmake
.PHONY : src/CMakeFiles/GraphClustering.dir/clean

src/CMakeFiles/GraphClustering.dir/depend:
	cd /run/media/konstantin/NameD/Home/git/GraphClusteringLib && $(CMAKE_COMMAND) -E cmake_depends "Unix Makefiles" /run/media/konstantin/NameD/Home/git/GraphClusteringLib /run/media/konstantin/NameD/Home/git/GraphClusteringLib/src /run/media/konstantin/NameD/Home/git/GraphClusteringLib /run/media/konstantin/NameD/Home/git/GraphClusteringLib/src /run/media/konstantin/NameD/Home/git/GraphClusteringLib/src/CMakeFiles/GraphClustering.dir/DependInfo.cmake --color=$(COLOR)
.PHONY : src/CMakeFiles/GraphClustering.dir/depend


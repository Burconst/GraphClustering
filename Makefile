#!/bin/bash

CC=g++
CFLAGS= -ansi -O5 -Wall
LDFLAGS= -ansi -lm -Wall
EXEC= testApp
OBJ1= graph_binary.o partition.o Louvain.o Output.o

all: $(EXEC)

community : $(OBJ1) main_community.o
	$(CC) -o $@ $^ $(LDFLAGS)

##########################################
# Generic rules
##########################################

%.o: %.cpp %.h
	$(CC) -o $@ -c $< $(CFLAGS)

%.o: %.cpp
	$(CC) -o $@ -c $< $(CFLAGS)

clean:
	rm -f *.o *~ $(EXEC)

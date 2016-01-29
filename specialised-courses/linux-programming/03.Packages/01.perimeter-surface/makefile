# Config

SRC_DIR=./src
OBJ_DIR=./objs

CCFLAGS=-std=c99 -c
LDFLAGS=-lm

SOURCES=$(notdir $(shell find $(SRC_DIR) -name '*.c'))
OBJECT_FILES=$(SOURCES:%.c=$(OBJ_DIR)/%.o)
TARGET_FILE=polygon-utils.exe

vpath %.c $(SRC_DIR)

# Rules
all: $(SOURCES) $(TARGET_FILE)

$(TARGET_FILE): $(OBJ_DIR) $(OBJECT_FILES)
	$(CC) $(LDFLAGS) $(OBJECT_FILES) -o $@

$(OBJ_DIR)/%.o: %.c
	$(CC) $(CCFLAGS) $< -o $@

$(OBJ_DIR):
	mkdir $(OBJ_DIR)

clean:
	-rm -f $(OBJ_DIR)/*.o $(TARGET_FILE)




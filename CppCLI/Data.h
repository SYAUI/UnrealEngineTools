#pragma once

static struct mem_block
{
	bool is_free;
	bool last_is_free;
	uintptr_t blocksize;//块大小
	uintptr_t next_block;
};

enum class BpNodeType
{
	Custom,
};


// 节点相关
enum class PinDirection
{
	EGPD_Input,
	EGPD_Output,
	EGPD_MAX,
};
enum class PinContainerType
{
	None,
	Array,
	Set,
	Map
};


struct BpPin
{
	BpNode* OwningNode;
	char* PinName;

};

// 链表
struct BpNode
{
	BpNode* next;
	BpNode* prev;
	unsigned int hash;
	BpNodeType type;
	char* name;
	char* parameter;
	BpPin** Pins;
	//BpPin pins[];
};
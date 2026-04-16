#include "pch.h"
#include "CppCLI.h"
#include "Data.h"
#include <fstream>

#define data_size 524288

using namespace std;

CppWrapper::AssetsOperator::!AssetsOperator()
{
	if (!data)
		delete[] data;
}


int CppWrapper::AssetsOperator::Debug_DumpData()
{
	ofstream outFile("Dump.dat", ios::out | ios::binary);
	outFile.write(data, data_size);
	outFile.close();
	return 0;
}

static int GetParamValue(string str, const char* Match, char* dp)
{
	int start, end;
	start = str.find(Match);
	if (start != string::npos)
	{
		start = start + strlen(Match)+1;
		end = str.find('"', start) + 1;
		string value = str.substr(start, end - start);
		strcpy(dp, value.c_str());
		return value.length();
	}
	else
		return 0;
}



int CppWrapper::AssetsOperator::Lexer()
{
	// 读入交换文件
	ifstream infile("NativeBp.tmp");
	if (!infile.is_open())
		return -1;

	bool inBlock = false;
	string line;
	int pos, start, end;

	BpNode* prev_node = (BpNode*)sym_header;
	prev_node->prev = nullptr;
	prev_node->next = nullptr;

	while (infile >> line)
	{
		BpNode*  curr_node = (BpNode*)dp;
		dp = dp + sizeof(BpNode) + 1;
		if (!inBlock)
		{
			if (line.find("Begin Object") != string::npos) 
				inBlock = true;
			pos = line.find("Class=/Script/BlueprintGraph.");

		}

	}


	return 0;
}



int CppWrapper::AssetsOperator::Blueprint2Cpp(bool IsBPGraph)
{
	if (!data)
		data = new char[data_size];
	if (!dp) 
		dp = data;

	sym_header = dp;
	dp = dp + sizeof(BpNode) + 1;



	if (IsBPGraph)
		return -1;
	else
		Lexer();


	return 0;
}



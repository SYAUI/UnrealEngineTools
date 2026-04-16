#pragma once


namespace CppWrapper {
	public ref class AssetsOperator
	{
	public:
		int Blueprint2Cpp(bool IsBPGraph);

		int Debug_DumpData();
	protected:
		!AssetsOperator();
	private:
		char* data;
		char* dp;
		void* sym_header;
		int Lexer();
	};
}

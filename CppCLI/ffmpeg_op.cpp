#include "pch.h"
#include "CppCli.h"
extern "C"
{
#include <libavcodec/avcodec.h>
#pragma comment(lib, "avcodec.lib")
#include <libavformat/avformat.h>
#pragma comment(lib, "avformat.lib")
#include <libavutil/imgutils.h>
#pragma comment(lib, "avutil.lib")
#include <libavutil/avutil.h>
#pragma comment(lib, "avutil.lib")
#include <libswscale/swscale.h>
#pragma comment(lib, "swscale.lib")
#include <libswresample/swresample.h>
#pragma comment(lib, "swresample.lib")
}
#include <vcclr.h>


class VideoOperator
{
public:
	bool LoadVideo(System::String^ path);
	bool ExtractAudio(System::String^ outpath);

private:
	void* pFormatCtx;
	int flag = 0;

};

struct WAVHeader {
	char     chunkID[4] = { 'R','I','F','F' };
	uint32_t chunkSize;
	char     format[4] = { 'W','A','V','E' };
	char     subchunk1ID[4] = { 'f','m','t',' ' };
	uint32_t subchunk1Size = 16;
	uint16_t audioFormat = 1;
	uint16_t numChannels;
	uint32_t sampleRate;
	uint32_t byteRate;
	uint16_t blockAlign;
	uint16_t bitsPerSample = 16;
	char     subchunk2ID[4] = { 'd','a','t','a' };
	uint32_t dataSize;

	void updateSizes(uint32_t dataSize) {
		this->dataSize = dataSize;
		chunkSize = 36 + dataSize;
	}
};





char* S2Char(System::String^ str)
{
	pin_ptr<const wchar_t> wch = PtrToStringChars(str);
	size_t convertedChars = 0;
	size_t  sizeInBytes = ((str->Length + 1) * 2);
	char* ch = (char*)malloc(sizeInBytes);
	wcstombs_s(&convertedChars, ch, sizeInBytes, wch, sizeInBytes);
	return ch;
}

bool VideoOperator::LoadVideo(System::String^ path)
{
	AVFormatContext* pfc = nullptr;

	char* filename = S2Char(path);
	flag = avformat_open_input(&pfc, filename, nullptr, nullptr);// 载入视频
	free(filename);
	filename = nullptr;

	if (flag < 0)
		return false;

	flag = avformat_find_stream_info(pfc, nullptr);// 获取流信息
	if (flag < 0)
		return false;

	pFormatCtx = pfc;

	return true;
}


bool VideoOperator::ExtractAudio(System::String^ outpath)
{
	AVFormatContext* input_fc = (AVFormatContext*)pFormatCtx;
	AVFormatContext* output_fc = nullptr;
	const AVCodec* codec;

	if (input_fc->nb_streams < 2) return false; // 含有音频的文件流数至少大于2

	for (unsigned int i = 0; i < input_fc->nb_streams; i++) {
		AVStream* stream = input_fc->streams[i];
		AVCodecParameters* codecpar = stream->codecpar;
		if (codecpar->codec_type == AVMEDIA_TYPE_AUDIO) // 找到音频流
		{
			codec = avcodec_find_decoder(codecpar->codec_id);


		}
	}



	return true;
}
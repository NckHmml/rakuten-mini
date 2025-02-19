# Local LLM
A small example of running a local LLM

Model used: https://huggingface.co/Rakuten/RakutenAI-2.0-mini-instruct

## Instructions
How to run the LLM, which works surprisingly well on CPU only

### Prerequisite
- ollama (For mac `brew install ollama`)

### Initialization

Open two terminal sessions, or write the following command to /dev/null
```
ollama serve
```

In the second session run
```
ollama create RakutenAI
ollama run RakutenAI
```

### Example command

Have the LLM create a React component
```
「Hello World」と書かれたReactコンポーネントを作成します。
コードのみ、テキストなし
```

Interestingly enough, the same command in English did not give similar results, which makes sense since a Japanese focused mini-llm was used.
But after tweaking the default parameters it gives more consistent results. 
```
Create a react component that says "Hello World".
Code only, no text.
```

The following should return that their name is "RakutenAI" as this has been specified as a system message
```
あなたの名前は何ですか
```

A somewhat longer prompt which needs quite some CPU resources;
```
履歴書を書いていただけますか？
```

### Notes
Either due this using a mini-llm, or perhaps a misconfiguration on my side, follow-up questions do not work as well as they should. use `/clear` between questions.

### Others

Convert to GGUF (requires gguf-py)
```
 ./.venv/bin/python convert_hf_to_gguf.py ./RakutenAI-2.0-mini-instruct --outfile RakutenAI-2.0-mini-instruct.gguf
 ```

Quantize example (requires llama.cpp)
 ```
 llama-quantize model.gguf RakutenAI-2.0-mini-instruct-Q4_K_M.gguf Q4_K_M
 ```
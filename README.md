Arithmetic-Coding
=================

Introduction
--------------------------------------
Arithmetic-Coding Exercises

Arithmetic-Coding Algorithm
--------------------------------------
Encode:

```bash
Step 1. low ← 0.0; high ← 1.0;
```
```bash
Step 2. read the next symbol c;
```
```bash
Step 3. range ← high - low;
```
```bash
Step 4. Check the intervals, assume l≤r<h
```
```bash
high ← low + range × h;
```
```bash
low ← low + range × l;
```
```bash
Step 5. If there are more symbols, repeat Step 2; otherwise , 
```
```bash
 go to step 6;
```
```bash
Step 6. return low;
```

Decode:

```bash
Step 1. Read the encoding value as number;
```
```bash
• Step 2. Find the intervals that the number falls within, 
```
```bash
assume l ≤ number < h, and the interval is associated with 
```
```bash
symbol c;
```
```bash
• Step 3. output c;
```
```bash
• Step 4. number ← number - l;
```
```bash
• Step 5. number ← number / (h - l); 
```
```bash
• Step 6. Repeat step 2 until the number is zero;
```


 Bugs
--------------------------------------
1.在編碼數字過多時，解碼會出現錯誤


My Website
--------------------------------------
[Press Me](http://vest12385.twbbs.org/)

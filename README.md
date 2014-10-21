Arithmetic-Coding
=================

Arithmetic-Coding Exercises

Arithmetic-Coding Algorithm
--------------------------------------
Encode:

```bash
Step 1. low ← 0.0; high ← 1.0;
Step 2. read the next symbol c;
Step 3. range ← high - low;
Step 4. Check the intervals, assume l≤r<h
high ← low + range × h;
low ← low + range × l;
Step 5. If there are more symbols, repeat Step 2; otherwise , 
 go to step 6;
Step 6. return low;
```

Decode:

```bash
Step 1. Read the encoding value as number;
• Step 2. Find the intervals that the number falls within, 
assume l ≤ number < h, and the interval is associated with 
symbol c;
• Step 3. output c;
• Step 4. number ← number - l;
• Step 5. number ← number / (h - l); 
• Step 6. Repeat step 2 until the number is zero;
```


 Bugs
--------------------------------------
1.在編碼數字過多時，解碼會出現錯誤

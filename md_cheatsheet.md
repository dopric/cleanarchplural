# Markdown Cheatsheet

# Headers
```
# H1
## H2
### H3
#### H4
##### H5
###### H6
```

# Emphasis
```
*This text will be italic*
_This will also be italic_

**This text will be bold**
__This will also be bold__

*You **can** combine them*
```

# Lists
## Unordered
```
* Item 1
* Item 2
  * Item 2a
  * Item 2b
```
## Ordered
```
1. Item 1
2. Item 2
3. Item 3
   * Item 3a
   * Item 3b
```

# Links
```
[GitHub](http://github.com)
```

# Images
```
![GitHub Logo](/images/logo.png)
Format: ![Alt Text](url)
```

# Blockquotes
```
As Kanye West said:

> We're living the future so
> the present is our past.
```

# Inline code
```
I think you should use an
`<addr>` element here instead.
```

# Code blocks
Wrap your code with three backticks (```) on the lines before and after your code:

\```python
print("Hello, World!")
\```

# Tables
```
| First Header  | Second Header |
| ------------- | ------------- |
| Content Cell  | Content Cell  |
| Content Cell  | Content Cell  |
```
# Styling tables
Styling can not be done in Markdown, but you can use HTML tags to style your tables.

<table style="width:100%">
  <tr>
    <th style="text-align:left">Firstname</th>
    <th style="text-align:left">Lastname</th> 
    <th style="text-align:left">Age</th>
  </tr>
  <tr>
    <td>Jill</td>
    <td>Smith</td> 
    <td>50</td>
  </tr>
  <tr>
    <td>Eve</td>
    <td>Jackson</td> 
    <td>94</td>
  </tr>
</table>

# Task Lists
```
- [x] @mentions, #refs, [links](), **formatting**, and <del>tags</del> supported
- [x] list syntax required (any unordered or ordered list supported)
- [ ] this is a complete item
- [ ] this is an incomplete item
```

# Strikethrough
```
Any word wrapped with two tildes (like ~~this~~) will appear crossed out.
```

# Emoji
```
GitHub supports emoji!
:grinning: :smiley: :wink:
```


For more details, you can visit the [GitHub Flavored Markdown Spec](https://github.github.com/gfm/).
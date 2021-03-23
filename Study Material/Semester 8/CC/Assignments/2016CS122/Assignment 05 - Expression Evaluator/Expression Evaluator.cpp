#include<iostream>
#include <string>

using namespace std;

class node
{
public:
    string data;
    node* left;
    node* right;

    node(string x)
    {
        data = x;
        left = NULL;
        right = NULL;
    }
};

int toInteger(string str)
{
    int number = 0;

    if (str[0] != '-')
        for (int i = 0; i < str.length(); i++)
            number = number * 10 + (int(str[i]) - 48);
    else
        for (int i = 1; i < str.length(); i++)
        {
            number = number * 10 + (int(str[i]) - 48);
            number = number * -1;
        }

    return number;
}

int evaluate(node* root)
{
    if (!root)
        return 0;

    if (!root->left && !root->right)
        return toInteger(root->data);

    int l_val = evaluate(root->left);
    int r_val = evaluate(root->right);

    if (root->data == "+")
        return l_val + r_val;
    if (root->data == "*")
        return l_val * r_val;
    if (root->data == "-")
        return l_val - r_val;
    return l_val / r_val;
}

void printPrefix(node* root)
{
    if (root != NULL)
    {
        cout << root->data << " ";
        printPrefix(root->left);
        printPrefix(root->right);
    }
}

void printInfix(node* root)
{
    if (root != NULL)
    {
        printInfix(root->left);
        cout << root->data << " ";
        printInfix(root->right);
    }
}

void printPostfix(node* root)
{
    if (root != NULL)
    {
        printPostfix(root->left);
        printPostfix(root->right);
        cout << root->data << " ";
    }
}
  
int main()
{
    node* root = new node("+");
    root->left = new node("*");
    root->left->left = new node("3");
    root->left->right = new node("1");
    root->right = new node("*");
    root->right->left = new node("7");
    root->right->right = new node("2");

    cout << "Infix Expression:      ";
    printInfix(root);
    cout << endl;
    cout << "Prefix Expression:     ";
    printPrefix(root);
    cout << endl;
    cout << "Postfix Expression:    ";
    printPostfix(root);
    cout << endl;
    cout <<"Result: "<< evaluate(root) << endl;

    delete(root);

    return 0;
}
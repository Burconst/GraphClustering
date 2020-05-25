#ifndef NODE_H
#define NODE_H

struct Node
{
    private:
        int _norm;
        int _number;
    public:
        Node();
        Node(int number, int norm);
        inline int GetNumber();
        inline int GetNorm();
};
inline int Node::GetNumber()
{
    return _number;
}

inline int Node::GetNorm()
{
    return _norm;
}



#endif // NODE_H
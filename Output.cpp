#include "Output.h"

using namespace std;

namespace Output 
{
    // Partition
    void DisplayPartitionInfo(Partition* partition)
    {
        cerr << endl << "<" ;
        for (int i=0 ; i<partition->size ; i++)
        {
            cerr << " " << i << "/" << partition->n2c[i] << "/" << partition->in[i] << "/" << partition->tot[i];
        }
        cerr << ">" << endl;
    }

    void DisplayPartition(Partition* partition)
    {
        vector<int> renumber(partition->size, -1);
        for (int node=0 ; node<partition->size ; node++)
        {
            renumber[partition->n2c[node]]++;
        }

        int final=0;
        for (int i=0 ; i<partition->size ; i++)
        {
            if (renumber[i]!=-1)
            {
            renumber[i]=final++;
            }
        }

        for (int i=0 ; i<partition->size ; i++)
        {
            cout << i << " " << renumber[partition->n2c[i]] << endl;
        }
    }

    void Partition2graph(Partition* partition)
    {
        vector<int> renumber(partition->size, -1);
        for (int node=0 ; node<partition->size ; node++)
        {
            renumber[partition->n2c[node]]++;
        }

        int final=0;
        for (int i=0 ; i<partition->size ; i++)
        {
            if (renumber[i]!=-1)
            {
            renumber[i]=final++;
            }
        }

        for (int i=0 ; i<partition->size ; i++)
        {
            pair<int *,int *> p = partition->g->Neighbors(i);

            int deg = partition->g->GetDergeeOf(i);
            for (int j=0 ; j<deg ; j++)
            {
            int neigh = *(p.first+j);
            cout << renumber[partition->n2c[i]] << " " << renumber[partition->n2c[neigh]] << endl;
            }
        }
    }

    // Graph
    void Display(Graph* g) 
    {
        for (int node=0 ; node<g->nbNodes ; node++) 
        {
            pair<int *,int *> p = g->Neighbors(node);
            for (int i=0 ; i<g->GetDergeeOf(node) ; i++) 
            {
            if (g->weights!=NULL) 
            {
                cout << node << " " << *(p.first+i) << " " << *(p.second+i) << endl;
            }
            else 
            {
                    cout << (node+1) << " " << (*(p.first+i)+1) << endl;
                //cout << (node) << " " << (*(p.first+i)) << endl;
            }
            }   
        }
    }
    void DisplayBinary(Graph* g, char *outfile)
    {
        ofstream foutput;
        foutput.open(outfile ,fstream::out | fstream::binary);

        foutput.write((char *)(&(g->nbNodes)),4);
        foutput.write((char *)(g->degrees),4*g->nbNodes);
        foutput.write((char *)(g->links),8*g->nbLinks);
    }
}


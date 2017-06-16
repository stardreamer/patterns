#include <stdio.h>
#include <stdlib.h>
#include <string.h>

typedef enum {
    INT,
    FLOAT,
    STRING,
    BOOLEAN
} TYPE;

typedef struct PointerWithElementNumber
{
    void* pointer;
    TYPE  type;
    unsigned int _count;

} PointerWithElementNumber;

typedef struct IGenericIEnumerator
{
    PointerWithElementNumber* _read_only_array;
    unsigned int _count;
    unsigned int _current_index;

    struct IGenericIEnumerator* _self_pointer;
    int (*move_next)(struct IGenericIEnumerator*);
    PointerWithElementNumber (*current)(struct IGenericIEnumerator*);
    void (*reset)(struct IGenericIEnumerator*);
} IGenericIEnumerator;

typedef struct GenericCollection
{
    struct GenericCollection* _self_pointer;
    PointerWithElementNumber* _array;
    unsigned int _count;
    IGenericIEnumerator* (*get_enumerator)(struct GenericCollection*);
} GenericCollection;

int generic_move_next(IGenericIEnumerator* enumerator)
{
    if(enumerator->_current_index == enumerator->_count - 1)
        return 0;
    enumerator->_current_index++;
    return 1;
}

PointerWithElementNumber generic_current(IGenericIEnumerator *enumerator)
{
    if(enumerator->_current_index < 0)
        printf("Call move_next() first!");

    return enumerator->_read_only_array[enumerator->_current_index];
}

void generic_reset(IGenericIEnumerator *enumerator)
{
     enumerator->_current_index = -1;
}

IGenericIEnumerator* generic_get_enumerator(GenericCollection* g_c)
{
    IGenericIEnumerator*  i_g_e = (IGenericIEnumerator*) malloc(sizeof(IGenericIEnumerator));

    i_g_e->_self_pointer = i_g_e;
    i_g_e->_count = g_c->_count;
    i_g_e->_read_only_array = g_c->_array;
    i_g_e->_current_index = -1;
    i_g_e->current = generic_current;
    i_g_e->move_next = generic_move_next;
    i_g_e->reset = generic_reset;

    return i_g_e;
}

void print_pointer_value(PointerWithElementNumber pwen)
{
    switch(pwen.type)
    {
        case INT:
            printf("%d\n", *((int*)pwen.pointer));
            break;
        case FLOAT:
            printf("%f\n", *((float*)pwen.pointer));
            break;
        case STRING:
            printf("%s\n", (char*)pwen.pointer);
            break;
        case BOOLEAN:
            printf("%s\n", (*(int*)pwen.pointer) ? "true": "false");
            break;
    }
}

int main()
{
    unsigned int stringLen = 8;
    char* string = (char*) malloc(stringLen*sizeof(char));
    strcpy(string, "covfefe\0");

    int int_value = 1;
    int bool_value = 1;
    float float_value = 123.4;

    unsigned int array_size = 4;
    PointerWithElementNumber* p_w_el_num_array = (PointerWithElementNumber*) malloc(array_size*sizeof(PointerWithElementNumber));

    p_w_el_num_array[0].pointer = &int_value;
    p_w_el_num_array[0]._count = 1;
    p_w_el_num_array[0].type = INT;

    p_w_el_num_array[1].pointer = string;
    p_w_el_num_array[1]._count = stringLen;
    p_w_el_num_array[1].type = STRING;

    p_w_el_num_array[2].pointer = &float_value;
    p_w_el_num_array[2]._count = 1;
    p_w_el_num_array[2].type = FLOAT;

    p_w_el_num_array[3].pointer = &bool_value;
    p_w_el_num_array[3]._count = 1;
    p_w_el_num_array[3].type = BOOLEAN;


    GenericCollection generic_collection;
    generic_collection.get_enumerator = generic_get_enumerator;
    generic_collection._array = p_w_el_num_array;
    generic_collection._count = array_size;
    generic_collection._self_pointer = &generic_collection;

    IGenericIEnumerator* generic_enumerator = generic_collection.get_enumerator(generic_collection._self_pointer);

    while(generic_enumerator->move_next(generic_enumerator))
    {
        print_pointer_value(generic_enumerator->current(generic_enumerator));
    }

    return 0;
}

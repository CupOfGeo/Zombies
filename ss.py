import random

def mod(a,b):
    c = -1
    while c != 0:
        print(a,b,c)
        c = a%b
        a = b
        b = c
    print(a,b,c)
    print('The GCD is: ', a)
    
def fib():
    f = 0
    d = 0
    e = 1
    while f < 1000:
        f = d + e
        d = e
        e = f
        print(d)


def crypto(alice,bob,prime,q):
    # Alice's number 
    # Bob's number 
    # prime number p such that p >> a,b (1061)
    # q random number
    bq = (bob*q)%prime
    aq = (alice*q)%prime
    key = (alice*bob*q)%prime
    print('aq mod p: ', aq)
    print('bq mod p: ', bq)
    print('key abq mod p: ', key)
    return[aq,bq,key]

def crack(aq,bq,q,prime):
    x=0
    while(aq != (x*q)%prime):
        x = 1+x
    print(x)
    y=0
    while(bq != (y*q)%prime):
        y = 1+y
    print(y)
    print('key :', (x*y*q)%prime)
def superCrypto(alice,bob,prime,q):
    # Alice's number
    # Bob's number
    # prime number p such that p >> a,b 1061
    # q random number
    bq = (q**bob)%prime
    aq = (q**alice)%prime
    key = (q**(alice*bob))%prime
    print('q^a mod p: ', (q**bob)%prime)
    print('q^b mod p: ', (q**alice)%prime)
    print('key q^(a*b) mod p: ', (q**(alice*bob))%prime)
    return[aq,bq,key]

def superCrack(a,b,q,prime):
    x=0
    while(a != (q**x)%prime):
        x = 1+x
    print(x)
    y = 0
    while(b != (q**y)%prime):
        y = 1+y
    print(y)
    print('key :', (q**(a*b))%prime)
    
def fun1():
    a = random.randint(0,999)  
    b = random.randint(0,999)
    p = 1061
    q = random.randint(0,999)
    print('alice:',a,'bob:',b,'q:',q,'prime: 1061')
    print('-----CRYPTO-----')
    list = crypto(a,b,p,q)
    print('-----CRACK-----')
    crack(list[0],list[1],q,p)
    print('-----SuperCRYPTO-----')
    list = superCrypto(a,b,p,q)
    print('-----SuperCRACK-----')
    superCrack(list[0],list[1],q,p)


# Tema 1 - Event driven pattern using Guava EventBus
### Enunt
Se considera un program care simuleaza activitatea unei fabrici de mobila. 
Fabrica are muncitori cu urmatoarele specializari:

- C = Cut seat
- F = Assemble feet
- B = Assemble backrest
- S = Assemble stabilizer bar
- P = Package chair

Procesul tehnologic impune urmatoarele restrictii: asamblarea picioarelor si a spatarului se pot face doar dupa ce a fost decupat sezutul, asamblarea barei se poate face doar dupa ce s-au pus picioarele, iar impachetarea dupa ce e gata asamblat scaunul. Fiecare faza a procesului tehnologic dureaza un timp diferit, influentata de complexitatea operatiei pe care o implica si de priceperea muncitorului care o executa.
Problema poate fi adaptata spre a fi modelata in stilurile: Pipes and Filters, Blackboard, si Event bus.

Muncitorii sunt sprijiniti de personal auxiliar (Event bus) care are rolul de a prelua un produs (un scaun neterminat) de la un muncitor care si-a terminat operatia si de a-l duce la un muncitor despre care se stie ca ar putea sa il continue. Personalul auxiliar a fost instruit in prealabil (Subscriptions for event types, filters) sa stie ce fel de produse accepta fiecare muncitor.
Esential in acest mod de abordare al problemei este stabilirea setului de evenimente.

De exemplu, un set de evenimente ar putea fi: NEED_F, NEED_B, NEED_S, NEED_P. Fiecare muncitor subscrie la tipul de evenimente corespunzator. Acest mod de a alege setul de evenimente are drept consecinta faptul ca fiecare muncitor trebuie sa cunoasca tot procesul tehnologic (trebuie sa stie ce alti muncitori pot fi chemati dupa ce isi termina operatia proprie).

Setul de evenimente ar mai putea fi stabilit in felul urmator: DONE_C, DONE_F, DONE_B, DONE_S, DONE_P. Fiecare muncitor va subscrie la evenimentele dupa care stie ca poate interveni ("minds his own business").

**Link** **_http://staff.cs.upt.ro/~ioana/arhit/2017/t1.html_**

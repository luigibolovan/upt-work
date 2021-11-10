# Enunturi exercitii

[Link lab](http://www.aut.upt.ro/~bgroza/teaching/SI/l3.pdf)

1. Form

2. Pentru acest exercițiu fiecare student va trebui să facă parte din cel putin o echipa de trei persoane (dacă este nevoie, puteți face parte din mai multe echipe fără ca efortul să se modifice). În cadrul fiecărei echipe se definesc trei roluri: A, B, și M. Scenariul exercițiului este următorul:


> A dorește să transmită un fișier text către B (fișierul va avea un conținut arbitrar). M este un adversar activ pe care îl emulăm ca fiind pe canalul de comunicare dintre A și B (deci, calea de transmisie a fișierului este  A->M->B). Deoarece A și B doresc să asigure integritatea fișierului trimis, A concatenează la transmisie un cod MAC calculat pe fișier folosind primitiva HMAC-SHA256 și o cheie secretă pe care presupunem că deja o partajează cu B (folosiți concatenarea prenumelor in ordine alfabetică, de exemplu pentru A = Ioana și B = Mihai, secretul va fi "IoanaMihai"). Înainte de a trimite mesajul mai departe, M are libera alegere de a modifica fișierul sau nu. La recepție, B trebuie să verifice și să raporteze dacă fișierul a fost alterat în vreun fel.
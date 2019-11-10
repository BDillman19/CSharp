using System;

public class Domino {
    public String state;

    public Domino(String state) {
        this.state = state;
    }

    public String fallLeft() {
        this.state = "L";
        return state;
    }

    public String fallRight() {
        this.state = "R";
        return state;
    }
}
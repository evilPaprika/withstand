public class Box : Creature
{
    private DropsOnDying dropChoice;

    protected void Start()
    {
        dropChoice = GetComponent<DropsOnDying>();
    }

    protected void Update()
    {
        if (IsDead())
            dropChoice.ChoiceItem();
    }   
}

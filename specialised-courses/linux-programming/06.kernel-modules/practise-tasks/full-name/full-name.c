#include <linux/kernel.h>
#include <linux/init.h>
#include <linux/module.h>

char * firstname = "Invalid first name";
char * lastname = "Invalid last name";
module_param(firstname, charp, 0);
module_param(lastname, charp, 0);

static int __init init(void) {
	printk(KERN_INFO "Hello %s, %s\n", lastname, firstname);	
	return 0;
}

static void __exit clean(void) {
	printk(KERN_INFO "Goodbye\n");
}

module_init(init);
module_exit(clean);

MODULE_LICENSE("GPL");
MODULE_AUTHOR("Preslav Mihaylov");
MODULE_DESCRIPTION("Prints out the full name input");
MODULE_PARM_DESC(firstName, "First name parameter");
MODULE_PARM_DESC(lastName, "Last name parameter");

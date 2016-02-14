#include <linux/kernel.h>
#include <linux/module.h>

void start_func(void) {
	printk(KERN_WARNING "Start\n");
}
